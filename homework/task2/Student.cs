namespace C_database
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
