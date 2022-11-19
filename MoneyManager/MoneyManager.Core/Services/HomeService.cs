using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Home;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repo;
        public HomeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ViewModel> DashboardByUserId(string userId)
        {
            var model = new ViewModel();

            //Incomes vs Expenses
            var incomes = repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId).Sum(x => x.Amount);

            var expenses = repo.AllReadonly<Expense>().Where(x => x.IsActive && x.ApplicationUserId == userId).Sum(x => x.Amount);

            var balance = Math.Abs(incomes - expenses);

            model.Totals = new TotalViewModel();
            model.Totals.IncomeTotal = incomes;
            model.Totals.ExpenseTotal = expenses;
            model.Totals.Balance = balance;

            //Incomes by categories

            model.IncomesCategories = new IncomesCategoriesViewModel();

            var categoriesIncome = await repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId).Select(c => c.Category.Name).Distinct().ToListAsync();

            model.IncomesCategories.CategoriesName = categoriesIncome;

            double sumIncomesByCategory;

            foreach (var category in categoriesIncome)
            {
                sumIncomesByCategory = (double)repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId && x.Category.Name == category).Sum(x => x.Amount);

                model.IncomesCategories.IncomesByCategoriesName.Add(sumIncomesByCategory);
            }

            return model;
        }
    }
}
