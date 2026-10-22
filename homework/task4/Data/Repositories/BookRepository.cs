using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using task4.Data.Models;

namespace task4.Data.Repositories
{
    internal sealed class BookRepository
    {
        public IList<Book> Search(string keyword)
        {
            var list = new List<Book>();
            var kw = (keyword ?? string.Empty).Trim();

            using (var conn = SQLiteDb.OpenConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (string.IsNullOrEmpty(kw))
                {
                    cmd.CommandText = "SELECT * FROM books ORDER BY updated_at DESC;";
                }
                else
                {
                    cmd.CommandText = @"SELECT * FROM books
WHERE title LIKE @k OR author LIKE @k OR isbn LIKE @k
ORDER BY updated_at DESC;";
                    cmd.Parameters.AddWithValue("@k", "%" + kw + "%");
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }

            return list;
        }

        public long Add(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            var now = DateTime.UtcNow;

            using (var conn = SQLiteDb.OpenConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO books(isbn,title,author,publisher,publish_date,price,stock,created_at,updated_at)
VALUES(@isbn,@title,@author,@publisher,@pdate,@price,@stock,@c,@u);
SELECT last_insert_rowid();";

                Bind(book, cmd, now, now);

                var idObj = cmd.ExecuteScalar();
                return Convert.ToInt64(idObj, CultureInfo.InvariantCulture);
            }
        }

        public void Update(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            var now = DateTime.UtcNow;

            using (var conn = SQLiteDb.OpenConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE books
SET isbn=@isbn,title=@title,author=@author,publisher=@publisher,publish_date=@pdate,price=@price,stock=@stock,updated_at=@u
WHERE id=@id;";

                cmd.Parameters.AddWithValue("@id", book.Id);
                Bind(book, cmd, null, now);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(long id)
        {
            using (var conn = SQLiteDb.OpenConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM books WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private static void Bind(Book book, SQLiteCommand cmd, DateTime? createdAt, DateTime updatedAt)
        {
            cmd.Parameters.AddWithValue("@isbn", (book.Isbn ?? string.Empty).Trim());
            cmd.Parameters.AddWithValue("@title", (book.Title ?? string.Empty).Trim());
            cmd.Parameters.AddWithValue("@author", (object)(book.Author ?? string.Empty));
            cmd.Parameters.AddWithValue("@publisher", (object)(book.Publisher ?? string.Empty));
            cmd.Parameters.AddWithValue("@pdate", book.PublishDate.HasValue ? (object)book.PublishDate.Value.ToString("yyyy-MM-dd") : DBNull.Value);
            cmd.Parameters.AddWithValue("@price", Convert.ToDouble(book.Price, CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@stock", book.Stock);

            if (createdAt.HasValue)
            {
                cmd.Parameters.AddWithValue("@c", createdAt.Value.ToString("o"));
            }

            cmd.Parameters.AddWithValue("@u", updatedAt.ToString("o"));
        }

        private static Book Map(SQLiteDataReader reader)
        {
            var b = new Book
            {
                Id = Convert.ToInt64(reader["id"], CultureInfo.InvariantCulture),
                Isbn = Convert.ToString(reader["isbn"]),
                Title = Convert.ToString(reader["title"]),
                Author = Convert.ToString(reader["author"]),
                Publisher = Convert.ToString(reader["publisher"]),
                Price = Convert.ToDecimal(reader["price"], CultureInfo.InvariantCulture),
                Stock = Convert.ToInt32(reader["stock"], CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Parse(Convert.ToString(reader["created_at"]), null, DateTimeStyles.RoundtripKind),
                UpdatedAt = DateTime.Parse(Convert.ToString(reader["updated_at"]), null, DateTimeStyles.RoundtripKind)
            };

            var pd = reader["publish_date"];
            if (pd != DBNull.Value)
            {
                DateTime parsed;
                if (DateTime.TryParse(Convert.ToString(pd), out parsed))
                    b.PublishDate = parsed;
            }

            return b;
        }
    }
}
