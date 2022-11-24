using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize(Roles ="User")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddAccountViewModel();
        
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAccountViewModel model)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

           var result= await accountService.AddAccountAsync(model, currentUserId);

            if (result == false)
            {
                ModelState.AddModelError("Name", "Account exist!");
                return View(model);
            }

            return RedirectToAction(nameof(All));

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

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await accountService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await accountService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await accountService.EditAsync(model);

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }

    }
}
