using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;
using System.Diagnostics;

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