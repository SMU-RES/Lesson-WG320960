using System;
using System.Security.Cryptography;
using System.Text;

namespace task4.Infrastructure
{
    internal static class Crypto
    {
        public static string Sha256(string input)
        {
            if (input == null) input = string.Empty;
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(bytes.Length * 2);
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
