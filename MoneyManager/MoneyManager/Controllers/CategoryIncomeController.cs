using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.CategoryIncome;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CategoryIncomeController : Controller
    {
        private readonly ICategoryIncomeService categoryIncomeService;
        public CategoryIncomeController(ICategoryIncomeService _categoryIncomeService)
        {
            categoryIncomeService = _categoryIncomeService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var model = await categoryIncomeService.GetAllAsync();

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCategoryIncomeViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryIncomeViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await categoryIncomeService.AddCategoryAsync(model);

            if (result == false)
            {
                ModelState.AddModelError("Name", "Category exist!");
                return View(model);
            }

            TempData["message"] = "You have successfully added a new income category!";


            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryIncomeService.GetForEditAsync(id);
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
        public async Task<IActionResult> Edit(EditCategoryIncomeViewModel model)
        {
            var sanitizer = new HtmlSanitizer();
            model.Name = sanitizer.Sanitize(model.Name);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryIncomeService.EditAsync(model);

            TempData["message"] = "You have successfully edited the income category!";

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }

    }
}
