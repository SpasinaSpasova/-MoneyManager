using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Services;
using MoneyManager.Infrastructure.Data;
using MoneyManager.Infrastructure.Data.Entities;
using System.Security.Claims;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class IncomeController : Controller
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

            //var model = new AddIncomeViewModel()
            //{
            // Categories = await incomeService.GetCategoriesIncomeAsync();
            //Accounts = await incomeService.GetAccountsByIdAsync(string currentUserId);
            //}
            return View(/*model*/);
        }
    }
}

