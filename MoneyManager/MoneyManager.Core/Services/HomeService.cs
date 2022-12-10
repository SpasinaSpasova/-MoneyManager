using MoneyManager.Infrastructure.Data.Common;
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

            //Incomes and Expenses totals
            IncomesAndExpensesTotals(userId, model);

            //Incomes and Expenses for week
            IncomesAndExpensesForWeek(userId, model);

            //Incomes by categories
            await IncomesByCategories(userId, model);

            //Expenses by categories
            await ExpensesByCategories(userId, model);

            return model;
        }

        private async Task ExpensesByCategories(string userId, ViewModel model)
        {
            model.ExpensesCategories = new ExpensesCategoriesViewModel();

            var categoriesExpense = await repo.AllReadonly<Expense>().Where(x => x.IsActive && x.ApplicationUserId == userId).Select(c => c.Category.Name).Distinct().ToListAsync();

            model.ExpensesCategories.CategoriesName = categoriesExpense;

            double sumExpenseByCategory;

            foreach (var category in categoriesExpense)
            {
                sumExpenseByCategory = (double)repo.AllReadonly<Expense>().Where(x => x.IsActive && x.ApplicationUserId == userId && x.Category.Name == category).Sum(x => x.Amount);

                model.ExpensesCategories.ExpensesByCategoriesName.Add(sumExpenseByCategory);
            }
        }

        private async Task IncomesByCategories(string userId, ViewModel model)
        {
            model.IncomesCategories = new IncomesCategoriesViewModel();

            var categoriesIncome = await repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId).Select(c => c.Category.Name).Distinct().ToListAsync();

            model.IncomesCategories.CategoriesName = categoriesIncome;

            double sumIncomesByCategory;

            foreach (var category in categoriesIncome)
            {
                sumIncomesByCategory = (double)repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId && x.Category.Name == category).Sum(x => x.Amount);

                model.IncomesCategories.IncomesByCategoriesName.Add(sumIncomesByCategory);
            }
        }

        private void IncomesAndExpensesForWeek(string userId, ViewModel model)
        {
            var incomesForWeek = repo.AllReadonly<Income>().Where(x => (x.IsActive) && (x.ApplicationUserId == userId) && (x.Date.Day <= DateTime.Today.Day || x.Date.Day > DateTime.Today.AddDays(-6).Day)).Sum(x => x.Amount);

            var expenseForWeek = repo.AllReadonly<Expense>().Where(x => (x.IsActive) && (x.ApplicationUserId == userId) && (x.Date.Day <= DateTime.Today.Day || x.Date.Day > DateTime.Today.AddDays(-6).Day)).Sum(x => x.Amount);

            model.IncomesAndExpensesForWeek = new IncomesAndExpensesForWeek();
            model.IncomesAndExpensesForWeek.Income = incomesForWeek;
            model.IncomesAndExpensesForWeek.Expense = expenseForWeek;
        }

        private void IncomesAndExpensesTotals(string userId, ViewModel model)
        {
            var incomes = repo.AllReadonly<Income>().Where(x => x.IsActive && x.ApplicationUserId == userId).Sum(x => x.Amount);

            var expenses = repo.AllReadonly<Expense>().Where(x => x.IsActive && x.ApplicationUserId == userId).Sum(x => x.Amount);

            var balance = Math.Abs(incomes - expenses);

            model.Totals = new TotalViewModel();
            model.Totals.IncomeTotal = incomes;
            model.Totals.ExpenseTotal = expenses;
            model.Totals.Balance = balance;
        }
    }
}
