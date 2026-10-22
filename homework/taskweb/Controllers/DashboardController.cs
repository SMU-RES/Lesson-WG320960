using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace taskweb.Controllers;

// 受保护页面：需要登录后访问。
[Authorize]
public sealed class DashboardController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // 前端页面通过 API 拉取最新采样数据。
        return View();
    }
}
