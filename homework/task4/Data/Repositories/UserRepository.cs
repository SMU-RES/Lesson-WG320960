using System;
using System.Data.SQLite;
using task4.Infrastructure;

namespace task4.Data.Repositories
{
    internal sealed class UserRepository
    {
        public bool ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password)) return false;

            using (var conn = SQLiteDb.OpenConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT password_hash FROM users WHERE username=@u LIMIT 1;";
                cmd.Parameters.AddWithValue("@u", username.Trim());

                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return false;

                var stored = Convert.ToString(result);
                var inputHash = Crypto.Sha256(password);
                return string.Equals(stored, inputHash, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
