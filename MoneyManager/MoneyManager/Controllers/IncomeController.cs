using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Income;
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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (currentUserId != null)
                {

                    await incomeService.AddIncomeAsync(model, currentUserId);
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
        public async Task<IActionResult> Upload(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                string fileName = file.FileName;

                using (MemoryStream ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    byte[] data = ms.ToArray();

                    //can save this byte array in database
                }
            }


            return Ok();
        }
    }
}


