using Microsoft.Data.SqlClient;
using task3.Models;

namespace task3.Data;

public class GradesAdoRepository
{
    private readonly string _connectionString;

    public GradesAdoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default")!;
    }

    public async Task<IReadOnlyList<GradeRecord>> QueryAsync(int? userId, string? courseName)
    {
        var results = new List<GradeRecord>();
        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
SELECT Id, UserId, CourseName, Score, ExamDate
FROM GradeRecords
WHERE ( @uid IS NULL OR UserId = @uid )
  AND ( @course IS NULL OR CourseName LIKE '%' + @course + '%' )
ORDER BY Id DESC;
";
        cmd.Parameters.AddWithValue("@uid", (object?)userId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@course", string.IsNullOrWhiteSpace(courseName) ? DBNull.Value : courseName.Trim());

        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            results.Add(new GradeRecord
            {
                Id = reader.GetInt32(0),
                UserId = reader.GetInt32(1),
                CourseName = reader.GetString(2),
                Score = reader.GetDecimal(3),
                ExamDate = reader.GetDateTime(4)
            });
        }

        return results;
    }

    public async Task<int> AddAsync(GradeRecord record)
    {
        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
INSERT INTO GradeRecords(UserId, CourseName, Score, ExamDate)
VALUES (@uid, @course, @score, @date);
SELECT CAST(SCOPE_IDENTITY() AS int);
";
        cmd.Parameters.AddWithValue("@uid", record.UserId);
        cmd.Parameters.AddWithValue("@course", record.CourseName);
        cmd.Parameters.AddWithValue("@score", record.Score);
        cmd.Parameters.AddWithValue("@date", record.ExamDate);

        var id = (int)(await cmd.ExecuteScalarAsync() ?? 0);
        return id;
    }

    public async Task UpdateAsync(GradeRecord record)
    {
        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
UPDATE GradeRecords
SET UserId = @uid,
    CourseName = @course,
    Score = @score,
    ExamDate = @date
WHERE Id = @id;
";
        cmd.Parameters.AddWithValue("@id", record.Id);
        cmd.Parameters.AddWithValue("@uid", record.UserId);
        cmd.Parameters.AddWithValue("@course", record.CourseName);
        cmd.Parameters.AddWithValue("@score", record.Score);
        cmd.Parameters.AddWithValue("@date", record.ExamDate);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM GradeRecords WHERE Id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<GradeRecord?> GetByIdAsync(int id)
    {
        await using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
SELECT Id, UserId, CourseName, Score, ExamDate
FROM GradeRecords
WHERE Id = @id;
";
        cmd.Parameters.AddWithValue("@id", id);

        await using var reader = await cmd.ExecuteReaderAsync();
        if (!await reader.ReadAsync()) return null;

        return new GradeRecord
        {
            Id = reader.GetInt32(0),
            UserId = reader.GetInt32(1),
            CourseName = reader.GetString(2),
            Score = reader.GetDecimal(3),
            ExamDate = reader.GetDateTime(4)
        };
    }
}
