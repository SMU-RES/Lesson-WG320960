using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace task
{
    // SQLite 仓储：负责表结构初始化与基础 CRUD。
    internal sealed class TelemetryRepository
    {
        private readonly string _connectionString;

        public TelemetryRepository(string dbFilePath)
        {
            if (string.IsNullOrWhiteSpace(dbFilePath)) throw new ArgumentNullException(nameof(dbFilePath));

            // 确保目录存在。
            var dir = Path.GetDirectoryName(dbFilePath);
            if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);

            // WAL + Normal：读写并发更友好（给 taskweb 只读查询用）。
            _connectionString = new SQLiteConnectionStringBuilder
            {
                DataSource = dbFilePath,
                ForeignKeys = true,
                JournalMode = SQLiteJournalModeEnum.Wal,
                SyncMode = SynchronizationModes.Normal,
                BusyTimeout = 5000
            }.ToString();
        }

        public void EnsureCreated()
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    // 两张表：TelemetrySamples（采样）+ AppLogs（运行日志）。
                    cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS TelemetrySamples (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TimestampUtc TEXT NOT NULL,
    TemperatureC REAL NOT NULL,
    VoltageV REAL NOT NULL,
    Rpm REAL NOT NULL,
    Source TEXT NOT NULL,
    Level TEXT NOT NULL
);
CREATE INDEX IF NOT EXISTS IX_TelemetrySamples_TimestampUtc ON TelemetrySamples(TimestampUtc);

CREATE TABLE IF NOT EXISTS AppLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TimestampUtc TEXT NOT NULL,
    Category TEXT NOT NULL,
    Message TEXT NOT NULL
);
CREATE INDEX IF NOT EXISTS IX_AppLogs_TimestampUtc ON AppLogs(TimestampUtc);
";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertSample(TelemetrySample s)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO TelemetrySamples(TimestampUtc, TemperatureC, VoltageV, Rpm, Source, Level)
VALUES(@ts, @t, @v, @rpm, @src, @lvl);";
                    cmd.Parameters.AddWithValue("@ts", s.TimestampUtc.ToString("o"));
                    cmd.Parameters.AddWithValue("@t", s.TemperatureC);
                    cmd.Parameters.AddWithValue("@v", s.VoltageV);
                    cmd.Parameters.AddWithValue("@rpm", s.Rpm);
                    cmd.Parameters.AddWithValue("@src", s.Source ?? string.Empty);
                    cmd.Parameters.AddWithValue("@lvl", s.Level ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertLog(string category, string message)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AppLogs(TimestampUtc, Category, Message) VALUES(@ts, @cat, @msg);";
                    cmd.Parameters.AddWithValue("@ts", DateTime.UtcNow.ToString("o"));
                    cmd.Parameters.AddWithValue("@cat", category ?? "INFO");
                    cmd.Parameters.AddWithValue("@msg", message ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable QueryTelemetrySamples(int limit)
        {
            // 桌面端表格查看：默认取最近 N 条。
            if (limit <= 0) limit = 1000;

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, TimestampUtc, TemperatureC, VoltageV, Rpm, Source, Level
FROM TelemetrySamples
ORDER BY Id DESC
LIMIT @lim;";
                    cmd.Parameters.AddWithValue("@lim", limit);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void DeleteTelemetrySample(long id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TelemetrySamples WHERE Id=@id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void TrimTelemetrySamples(int keepLatest)
        {
            // 保留最近 keepLatest 条，避免库无限增长。
            if (keepLatest <= 0) return;

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM TelemetrySamples
WHERE Id NOT IN (
    SELECT Id FROM TelemetrySamples ORDER BY Id DESC LIMIT @keep
);";
                    cmd.Parameters.AddWithValue("@keep", keepLatest);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
