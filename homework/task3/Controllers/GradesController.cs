using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3.Data;
using task3.Models;

namespace task3.Controllers;

public class GradesController : Controller
{
    private readonly GradesAdoRepository _repo;
    private readonly AppDbContext _db;

    public GradesController(GradesAdoRepository repo, AppDbContext db)
    {
        _repo = repo;
        _db = db;
    }

    private int? CurrentUserId => HttpContext.Session.GetInt32("UserId");

    private IActionResult RequireLogin()
    {
        if (CurrentUserId is null) return RedirectToAction("Index", "Login");
        return null!;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? userId, string? course)
    {
        var guarded = RequireLogin();
        if (guarded is not null) return guarded;

        ViewBag.Users = await _db.Users.OrderBy(x => x.UserName).ToListAsync();
        ViewBag.FilterUserId = userId;
        ViewBag.FilterCourse = course;

        var rows = await _repo.QueryAsync(userId, course);
        return View(rows);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int userId, string courseName, decimal score, DateTime examDate)
    {
        var guarded = RequireLogin();
        if (guarded is not null) return guarded;

        if (string.IsNullOrWhiteSpace(courseName))
            return RedirectToAction(nameof(Index));

        await _repo.AddAsync(new GradeRecord
        {
            UserId = userId,
            CourseName = courseName.Trim(),
            Score = score,
            ExamDate = examDate
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, int userId, string courseName, decimal score, DateTime examDate)
    {
        var guarded = RequireLogin();
        if (guarded is not null) return guarded;

        await _repo.UpdateAsync(new GradeRecord
        {
            Id = id,
            UserId = userId,
            CourseName = courseName.Trim(),
            Score = score,
            ExamDate = examDate
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var guarded = RequireLogin();
        if (guarded is not null) return guarded;

        await _repo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
