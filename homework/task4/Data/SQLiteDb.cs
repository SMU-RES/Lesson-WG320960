using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using task4.Infrastructure;

namespace task4.Data
{
    internal static class SQLiteDb
    {
        public static string ConnectionString => new SQLiteConnectionStringBuilder
        {
            DataSource = DbPaths.DbFilePath,
            ForeignKeys = true
        }.ToString();

        public static void Initialize()
        {
            try
            {
                var firstRun = !File.Exists(DbPaths.DbFilePath);
                if (firstRun)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(DbPaths.DbFilePath) ?? ".");
                    SQLiteConnection.CreateFile(DbPaths.DbFilePath);
                }

                using (var conn = OpenConnection())
                {
                    CreateSchema(conn);
                    SeedDefaultAdmin(conn);
                    SeedSampleBooks(conn);
                }

                Logger.Info("Database initialized at " + DbPaths.DbFilePath);
            }
            catch (Exception ex)
            {
                Logger.Error("Database initialization failed", ex);
                throw;
            }
        }

        public static SQLiteConnection OpenConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "PRAGMA journal_mode=WAL;";
                cmd.ExecuteNonQuery();
            }
            return conn;
        }

        private static void CreateSchema(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS users(
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  username TEXT NOT NULL UNIQUE,
  password_hash TEXT NOT NULL,
  created_at TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS books(
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  isbn TEXT NOT NULL UNIQUE,
  title TEXT NOT NULL,
  author TEXT,
  publisher TEXT,
  publish_date TEXT,
  price REAL NOT NULL DEFAULT 0,
  stock INTEGER NOT NULL DEFAULT 0,
  created_at TEXT NOT NULL,
  updated_at TEXT NOT NULL
);
";
                cmd.ExecuteNonQuery();
            }
        }

        private static void SeedDefaultAdmin(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM users WHERE username=@u;";
                cmd.Parameters.AddWithValue("@u", "admin");
                var exists = Convert.ToInt32(cmd.ExecuteScalar(), CultureInfo.InvariantCulture) > 0;
                if (exists) return;
            }

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO users(username,password_hash,created_at) VALUES(@u,@p,@t);";
                cmd.Parameters.AddWithValue("@u", "admin");
                cmd.Parameters.AddWithValue("@p", Crypto.Sha256("admin123"));
                cmd.Parameters.AddWithValue("@t", DateTime.UtcNow.ToString("o"));
                cmd.ExecuteNonQuery();
            }

            Logger.Info("Seeded default admin user: admin / admin123");
        }

        private static void SeedSampleBooks(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM books;";
                var count = Convert.ToInt32(cmd.ExecuteScalar(), CultureInfo.InvariantCulture);
                if (count > 0) return;
            }

            var now = DateTime.UtcNow;

            using (var tx = conn.BeginTransaction())
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = @"INSERT INTO books(isbn,title,author,publisher,publish_date,price,stock,created_at,updated_at)
VALUES(@isbn,@title,@author,@publisher,@pdate,@price,@stock,@c,@u);";

                void Add(string isbn, string title, string author, string publisher, string publishDate, double price, int stock)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", (object)author ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@publisher", (object)publisher ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pdate", (object)publishDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@c", now.ToString("o"));
                    cmd.Parameters.AddWithValue("@u", now.ToString("o"));
                    cmd.ExecuteNonQuery();
                }

                Add("9787302423287", "C#程序设计（第X版）", "（示例）", "清华大学出版社", "2016-01-01", 59.00, 10);
                Add("9787115428028", "深入理解计算机系统", "Randal E. Bryant", "人民邮电出版社", "2016-11-01", 139.00, 5);
                Add("9787111128069", "代码大全（第2版）", "Steve McConnell", "电子工业出版社", "2010-01-01", 128.00, 3);
                Add("9787111213826", "设计模式：可复用面向对象软件的基础", "Erich Gamma", "机械工业出版社", "2007-01-01", 79.00, 4);
                Add("9787111544937", "算法（第4版）", "Robert Sedgewick", "人民邮电出版社", "2012-10-01", 99.00, 6);

                tx.Commit();
            }

            Logger.Info("Seeded sample books");
        }
    }
}
