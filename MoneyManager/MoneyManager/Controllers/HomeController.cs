using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}