using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        private readonly ILogger logger;

        public HomeController(IHomeService _homeService, ILogger<HomeController> _logger)
        {
            homeService = _homeService;
            logger = _logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == null)
            {
                return View();
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return RedirectToAction(nameof(Dashboard));
        }

        public async Task<ActionResult> Dashboard()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var model = await homeService.DashboardByUserId(currentUserId);

            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}