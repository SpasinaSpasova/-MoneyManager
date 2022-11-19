using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Services;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService _homeService)
        {
            homeService = _homeService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == null)
            {
                return View();
            }

            return RedirectToAction(nameof(Dashboard));
        }


        public async Task<ActionResult> Dashboard()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var model = await homeService.DashboardByUserId(currentUserId);
            
            return View(model);

        }
    }
}