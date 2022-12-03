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

        public async Task<ActionResult> Dashboard()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var model = await homeService.DashboardByUserId(currentUserId);

            return View(model);

        }
    }
}
