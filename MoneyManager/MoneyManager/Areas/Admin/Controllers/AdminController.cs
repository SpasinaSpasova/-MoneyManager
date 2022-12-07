using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Services;
using System.Security.Claims;

namespace MoneyManager.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IHomeService homeService;
        public AdminController(IHomeService _homeService)
        {
            homeService = _homeService;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
