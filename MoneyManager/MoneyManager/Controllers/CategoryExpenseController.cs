using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.CategoryExpense;

namespace MoneyManager.Controllers
{
    [Authorize]
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


            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryExpenseService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryExpenseViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryExpenseService.EditAsync(model);

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }

    }
}
