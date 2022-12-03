using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Areas.Admin.Controllers;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Income;
using MoneyManager.Core.Services;
using System.Security.Claims;

namespace MoneyManager.Areas.Admin.Controllers
{
    public class IncomeController : BaseController
    {

        private readonly IIncomeService incomeService;
        public IncomeController(IIncomeService _incomeService)
        {
            incomeService = _incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId != null)
            {
                var model = await incomeService.GetAllByUserIdAsync(currentUserId);

                return View(model);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId != null)
            {
                var model = new AddIncomeViewModel()
                {
                    Categories = await incomeService.GetCategoriesIncomeAsync(),
                    Accounts = await incomeService.GetAccountsByIdAsync(currentUserId)
                };

                return View(model);
            }
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIncomeViewModel model)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            model.Categories = await incomeService.GetCategoriesIncomeAsync();

            model.Accounts = await incomeService.GetAccountsByIdAsync(currentUserId);

            var sanitizer = new HtmlSanitizer();
            model.Description = sanitizer.Sanitize(model.Description);

            if (model.Description.Length == 0)
            {
                model.Description = null;
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.CategoryId == new Guid { } || model.AccountId == new Guid { })
            {
                ModelState.AddModelError("", "Something went wrong.");

                return View(model);
            }

            try
            {
                if (currentUserId != null)
                {
                    await incomeService.AddIncomeAsync(model, currentUserId);
                }
                TempData["message"] = "You have successfully added a new income!";

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong.");

                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await incomeService.GetForEditAsync(id);

            if (model.Id != new Guid())
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (currentUserId != null)
                {

                    model.Categories = await incomeService.GetCategoriesIncomeAsync();
                    model.Accounts = await incomeService.GetAccountsByIdAsync(currentUserId);
                }

                return View(model);

            }
            else
            {
                ModelState.AddModelError("", "You do not have access!");
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditIncomeViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Description = sanitizer.Sanitize(model.Description);

            if (model.Description.Length == 0)
            {
                model.Description = null;
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await incomeService.EditAsync(model);

            TempData["message"] = "You have successfully edited the income!";


            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] Guid id, IFormFileCollection file)
        {
            await incomeService.UploadAsync(id, file);
            return RedirectToAction(nameof(All));

        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {
            await incomeService.DeleteAsync(id);

            TempData["message"] = "You have successfully deleted the income!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }
    }
}


