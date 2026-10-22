using System.Data;
using System.Data.SQLite;

namespace C_database
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentDatabase.db");
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentDatabase.db")))
            {
                SQLiteConnection.CreateFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentDatabase.db"));
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        StudentNumber TEXT NOT NULL,
                        Subject TEXT NOT NULL,
                        Score REAL NOT NULL,
                        ExamDate TEXT NOT NULL
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllStudents()
        {
            DataTable dataTable = new DataTable();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students ORDER BY Id";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable SearchStudents(string name = "", string studentNumber = "", string subject = "")
        {
            DataTable dataTable = new DataTable();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students WHERE 1=1";
                
                if (!string.IsNullOrEmpty(name))
                    query += " AND Name LIKE @Name";
                if (!string.IsNullOrEmpty(studentNumber))
                    query += " AND StudentNumber LIKE @StudentNumber";
                if (!string.IsNullOrEmpty(subject))
                    query += " AND Subject LIKE @Subject";

                query += " ORDER BY Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(name))
                        command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    if (!string.IsNullOrEmpty(studentNumber))
                        command.Parameters.AddWithValue("@StudentNumber", "%" + studentNumber + "%");
                    if (!string.IsNullOrEmpty(subject))
                        command.Parameters.AddWithValue("@Subject", "%" + subject + "%");

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public void AddStudent(Student student)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Students (Name, StudentNumber, Subject, Score, ExamDate) 
                                VALUES (@Name, @StudentNumber, @Subject, @Score, @ExamDate)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@Score", student.Score);
                    command.Parameters.AddWithValue("@ExamDate", student.ExamDate.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Students 
                                SET Name = @Name, 
                                    StudentNumber = @StudentNumber, 
                                    Subject = @Subject, 
                                    Score = @Score, 
                                    ExamDate = @ExamDate 
                                WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@Score", student.Score);
                    command.Parameters.AddWithValue("@ExamDate", student.ExamDate.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Students WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudentFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string query = @"UPDATE Students 
                                                SET Name = @Name, 
                                                    StudentNumber = @StudentNumber, 
                                                    Subject = @Subject, 
                                                    Score = @Score, 
                                                    ExamDate = @ExamDate 
                                                WHERE Id = @Id";

                                using (var command = new SQLiteCommand(query, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Id", row["Id"]);
                                    command.Parameters.AddWithValue("@Name", row["Name"]);
                                    command.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"]);
                                    command.Parameters.AddWithValue("@Subject", row["Subject"]);
                                    command.Parameters.AddWithValue("@Score", row["Score"]);
                                    command.Parameters.AddWithValue("@ExamDate", Convert.ToDateTime(row["ExamDate"]).ToString("yyyy-MM-dd"));
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
