namespace task3.Models;

public class GradeRecord
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public DateTime ExamDate { get; set; }
}
