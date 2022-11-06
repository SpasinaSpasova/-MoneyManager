using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Services;
using MoneyManager.Infrastructure.Data;
using MoneyManager.Infrastructure.Data.Entities;

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
            var model = await incomeService.GetAllAsync();

            return View(model);
        }
      
    }
}
