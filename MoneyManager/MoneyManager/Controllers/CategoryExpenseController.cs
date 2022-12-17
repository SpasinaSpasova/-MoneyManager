using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.CategoryExpense;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CategoryExpenseController : Controller
    {
        private readonly ICategoryExpenseService categoryExpenseService;
        public CategoryExpenseController(ICategoryExpenseService _categoryExpenseService)
        {
            categoryExpenseService = _categoryExpenseService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var model = await categoryExpenseService.GetAllAsync();

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCategoryExpenseViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryExpenseViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await categoryExpenseService.AddCategoryAsync(model);

            if (result == false)
            {
                ModelState.AddModelError("Name", "Category exist!");
                return View(model);
            }

            TempData["message"] = "You have successfully added a new expense category!";

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryExpenseService.GetForEditAsync(id);

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
        public async Task<IActionResult> Edit(EditCategoryExpenseViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await categoryExpenseService.EditAsync(model);

            if (result)
            {

                TempData["message"] = "You have successfully edited the expense category!";
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
