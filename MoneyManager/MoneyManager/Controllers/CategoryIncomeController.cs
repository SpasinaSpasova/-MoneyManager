using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.CategoryIncome;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User")]
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
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result= await categoryIncomeService.AddCategoryAsync(model);

            if (result==false)
            {
                ModelState.AddModelError("Name", "Category exist!");
                return View(model);
            }


            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryIncomeService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryIncomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryIncomeService.EditAsync(model);

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(All));
        }

    }
}
