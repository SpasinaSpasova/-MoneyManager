using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Expense;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize(Roles = "User")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService expenseService;
        public ExpenseController(IExpenseService _expenseService)
        {
            expenseService = _expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId != null)
            {
                var model = await expenseService.GetAllByUserIdAsync(currentUserId);

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
                var model = new AddExpenseViewModel()
                {
                    Categories = await expenseService.GetCategoriesExpenseAsync(),
                    Accounts = await expenseService.GetAccountsByIdAsync(currentUserId)
                };

                return View(model);
            }
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseViewModel model)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            model.Categories = await expenseService.GetCategoriesExpenseAsync();

            model.Accounts = await expenseService.GetAccountsByIdAsync(currentUserId);

            var account = model.Accounts.FirstOrDefault(x => x.Id == model.AccountId);


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
                if (currentUserId != null && account != null)
                {
                    if (account.Amount < model.Amount)
                    {

                        ModelState.AddModelError("Amount", "The amount on the account is insufficient! Please enter a new amount, or select a different account!");
                        return View(model);
                    }

                    await expenseService.AddExpenseAsync(model, currentUserId);
                }

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong.");

                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] Guid id, IFormFileCollection file)
        {

            await expenseService.UploadAsync(id, file);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {
            await expenseService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await expenseService.GetForEditAsync(id);

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId != null)
            {

                model.Categories = await expenseService.GetCategoriesExpenseAsync();
                model.Accounts = await expenseService.GetAccountsByIdAsync(currentUserId);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditExpenseViewModel model)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            model.Categories = await expenseService.GetCategoriesExpenseAsync();

            model.Accounts = await expenseService.GetAccountsByIdAsync(currentUserId);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await expenseService.EditAsync(model);

            if (result ==false)
            {
                ModelState.AddModelError("Amount", "The amount on the account is insufficient! Please enter a new amount, or select a different account!");
                return View(model);
            }
            else
            {

                return RedirectToAction(nameof(All));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            return  RedirectToAction(nameof(All));
        }
    }
}
