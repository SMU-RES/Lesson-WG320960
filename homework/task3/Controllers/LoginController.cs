using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3.Data;

namespace task3.Controllers;

public class LoginController : Controller
{
    private readonly AppDbContext _db;

    public LoginController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UserId") is not null)
            return RedirectToAction("Index", "Grades");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(string userName, string password)
    {
        var hash = DbInitializer.Sha256(password ?? string.Empty);
        var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.PasswordHash == hash);

        if (user is null)
        {
            ViewBag.Error = "用户名或密码错误";
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("UserName", user.UserName);

        return RedirectToAction("Index", "Grades");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index));
    }
}
