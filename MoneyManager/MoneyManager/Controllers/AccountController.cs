using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User,Admin")]
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

            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await accountService.AddAccountAsync(model, currentUserId);

            if (result == false)
            {
                ModelState.AddModelError("Name", "Account exist!");
                return View(model);
            }

            TempData["message"] = "You have successfully added a new account!";


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

            TempData["message"] = "You have successfully deleted the account!";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await accountService.GetForEditAsync(id);

            if (model.Id != new Guid())
            {
                return View(model);

            }
            else
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await accountService.EditAsync(model, currentUserId);

            if (result)
            {
                TempData["message"] = "You have successfully edited the account!";

            }


            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }

    }
}
