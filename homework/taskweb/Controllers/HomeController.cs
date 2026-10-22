using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using taskweb.Models;

namespace taskweb.Controllers
{
    // 站点入口与通用页面。
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // 默认跳转到仪表盘。
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // 透出 RequestId 便于排查。
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
