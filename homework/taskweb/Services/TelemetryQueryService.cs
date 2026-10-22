using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace taskweb.Services;

public sealed class TelemetryQueryService
{
    private readonly string _dbPath;

    public TelemetryQueryService(IOptions<TelemetryDbOptions> options)
    {
        // 来自配置的 SQLite 文件路径（与桌面端共用同一库）。
        _dbPath = options.Value.DbPath ?? string.Empty;
    }

    public async Task<IReadOnlyList<TelemetrySampleDto>> GetLatestSamplesAsync(int limit, CancellationToken ct = default)
    {
        // 保护性约束：避免过小/过大查询导致无意义或过重的读压力。
        if (limit <= 0) limit = 500;
        if (limit > 5000) limit = 5000;

        // 没有库文件时直接返回空结果（页面可用，但无数据）。
        if (string.IsNullOrWhiteSpace(_dbPath) || !File.Exists(_dbPath)) return Array.Empty<TelemetrySampleDto>();

        // Web 端只读打开，避免对桌面端写入造成抢占/锁竞争。
        var cs = new SqliteConnectionStringBuilder
        {
            DataSource = _dbPath,
            Mode = SqliteOpenMode.ReadOnly
        }.ToString();

        await using var conn = new SqliteConnection(cs);
        await conn.OpenAsync(ct);

        await using var cmd = conn.CreateCommand();
        // 按自增 Id 倒序取最近 N 条（与桌面端写入顺序一致）。
        cmd.CommandText = @"
SELECT Id, TimestampUtc, TemperatureC, VoltageV, Rpm, Source, Level
FROM TelemetrySamples
ORDER BY Id DESC
LIMIT $lim;";
        cmd.Parameters.AddWithValue("$lim", limit);

        // 预分配容量，减少列表扩容。
        var list = new List<TelemetrySampleDto>(limit);

        await using var reader = await cmd.ExecuteReaderAsync(ct);
        while (await reader.ReadAsync(ct))
        {
            var id = reader.GetInt64(0);
            var tsText = reader.GetString(1);

            // TimestampUtc 使用 round-trip 格式写入；解析失败则保留默认值。
            _ = DateTime.TryParse(
                tsText,
                provider: null,
                styles: System.Globalization.DateTimeStyles.RoundtripKind,
                result: out var ts);

            list.Add(new TelemetrySampleDto(
                id,
                ts,
                reader.GetDouble(2),
                reader.GetDouble(3),
                reader.GetDouble(4),
                reader.GetString(5),
                reader.GetString(6)));
        }

        return list;
    }
}
