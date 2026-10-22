using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using task3.Models;

namespace task3.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(WebApplication app)
    {
        await EnsureCreatedEfAsync(app);
        await EnsureCreatedAdoAsync(app);
        await SeedAsync(app);
    }

    private static async Task EnsureCreatedEfAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureCreatedAsync();
    }

    private static async Task EnsureCreatedAdoAsync(WebApplication app)
    {
        var cs = app.Configuration.GetConnectionString("Default")!;
        await using var conn = new SqlConnection(cs);
        await conn.OpenAsync();

        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
IF OBJECT_ID(N'dbo.GradeRecords', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.GradeRecords (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_GradeRecords PRIMARY KEY,
        UserId INT NOT NULL,
        CourseName NVARCHAR(200) NOT NULL,
        Score DECIMAL(5,2) NOT NULL,
        ExamDate DATE NOT NULL
    );
END
";
        await cmd.ExecuteNonQueryAsync();
    }

    private static async Task SeedAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!await db.Users.AnyAsync())
        {
            db.Users.Add(new User
            {
                UserName = "student",
                PasswordHash = Sha256("123456")
            });
            await db.SaveChangesAsync();
        }

        var cs = app.Configuration.GetConnectionString("Default")!;
        await using var conn = new SqlConnection(cs);
        await conn.OpenAsync();

        await using var check = conn.CreateCommand();
        check.CommandText = "SELECT COUNT(1) FROM dbo.GradeRecords";
        var count = (int)(await check.ExecuteScalarAsync() ?? 0);

        if (count == 0)
        {
            var userId = await db.Users.Where(x => x.UserName == "student").Select(x => x.Id).FirstAsync();

            await using var insert = conn.CreateCommand();
            insert.CommandText = @"
INSERT INTO dbo.GradeRecords(UserId, CourseName, Score, ExamDate)
VALUES (@uid, @course, @score, @date);
";
            insert.Parameters.AddWithValue("@uid", userId);
            insert.Parameters.AddWithValue("@course", "C#≥Ã–Ú…Ëº∆");
            insert.Parameters.AddWithValue("@score", 92.5m);
            insert.Parameters.AddWithValue("@date", DateTime.UtcNow.Date);
            await insert.ExecuteNonQueryAsync();
        }
    }

    public static string Sha256(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}
