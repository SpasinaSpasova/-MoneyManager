using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Services;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId != null)
            {
                var model = await accountService.GetAllByUserIdAsync(currentUserId);

                return View(model);
            }


            return View();
        }
    }
}
