using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Infrastructure.Data.Common;
using MoneyManager.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Core.Services;
using MoneyManager.Infrastructure.Data.Entities;
using MoneyManager.Core.Models.Home;

namespace MoneyManager.UnitTests
{
    [TestFixture]
    public class HomeServiceTests
    {
        private IRepository _repo;
        private IHomeService homeService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("HomeDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task DashboardByCurrentUser_1()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser() {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", 
                FirstName = "user1", 
                LastName = "user1" 
            };

            await repo.AddAsync<ApplicationUser>(user);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.Totals.IncomeTotal, Is.EqualTo(0));
            Assert.That(model.Totals.ExpenseTotal, Is.EqualTo(0));
            Assert.That(model.Totals.Balance, Is.EqualTo(0));
        }

        [Test]
        public async Task DashboardByCurrentUser_2()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            await repo.AddAsync<ApplicationUser>(user);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.IncomesCategories.CategoriesName.Count, Is.EqualTo(0));
            Assert.That(model.IncomesCategories.IncomesByCategoriesName.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task DashboardByCurrentUser_3()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            await repo.AddAsync<ApplicationUser>(user);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.ExpensesCategories.CategoriesName.Count, Is.EqualTo(0));
            Assert.That(model.ExpensesCategories.ExpensesByCategoriesName.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task DashboardByCurrentUser_4()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            await repo.AddAsync<ApplicationUser>(user);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.IncomesAndExpensesForWeek.Income, Is.EqualTo(0));
            Assert.That(model.IncomesAndExpensesForWeek.Expense, Is.EqualTo(0));
        }

        [Test]
        public async Task DashboardByCurrentUser_5()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                Amount = 50.20m,
                Name = "Account",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Income income = new Income()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 20,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            Expense expense = new Expense()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 30,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Income>(income);
            await repo.AddAsync<Expense>(expense);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.IncomesAndExpensesForWeek.Income, Is.EqualTo(20));
            Assert.That(model.IncomesAndExpensesForWeek.Expense, Is.EqualTo(30));
        }

        [Test]
        public async Task DashboardByCurrentUser_6()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                Amount = 50.20m,
                Name = "Account",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Income income = new Income()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 20,
                Description = "test",
                Date = DateTime.Today,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            Expense expense = new Expense()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 30,
                Description = "test",
                Date = DateTime.Today.AddDays(-10),
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Income>(income);
            await repo.AddAsync<Expense>(expense);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.IncomesAndExpensesForWeek.Income, Is.EqualTo(20));
            Assert.That(model.IncomesAndExpensesForWeek.Expense, Is.EqualTo(0));
        }

        [Test]
        public async Task DashboardByCurrentUser_7()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                Amount = 50.20m,
                Name = "Account",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Income income = new Income()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 20,
                Description = "test",
                Date = DateTime.Today,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            Expense expense = new Expense()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 30,
                Description = "test",
                Date = DateTime.Today.AddDays(-10),
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Income>(income);
            await repo.AddAsync<Expense>(expense);


            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.Totals.IncomeTotal, Is.EqualTo(20));
            Assert.That(model.Totals.ExpenseTotal, Is.EqualTo(30));
            Assert.That(model.Totals.Balance, Is.EqualTo(10));
        }

        [Test]
        public async Task DashboardByCurrentUser_8()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                Amount = 50.20m,
                Name = "Account",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            CategoryExpense categoryExpense = new CategoryExpense()
            {
                Id = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Name = "cat"
            };

            Expense expense = new Expense()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 30,
                Description = "test",
                Date = DateTime.Today.AddDays(-10),
                CategoryId = categoryExpense.Id,
                Category=categoryExpense,
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Expense>(expense);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.ExpensesCategories.CategoriesName.Count, Is.EqualTo(1));
            Assert.That(model.ExpensesCategories.ExpensesByCategoriesName.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DashboardByCurrentUser_9()
        {
            var repo = new Repository(applicationDbContext);
            homeService = new HomeService(repo);


            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                Amount = 50.20m,
                Name = "Account",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            CategoryIncome categoryIncome = new CategoryIncome()
            {
                Id = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                Name = "cat"
            };

            Income income = new Income()
            {
                Id = new Guid("f2712406-43b4-46df-90be-933e106fb91c"),
                Amount = 30,
                Description = "test",
                Date = DateTime.Today.AddDays(-10),
                CategoryId = categoryIncome.Id,
                Category = categoryIncome,
                Account = account,
                AccountId = account.Id,
                ApplicationUser = user,
                ApplicationUserId = user.Id,

            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Income>(income);

            await repo.SaveChangesAsync();

            ViewModel model = await homeService.DashboardByUserId(user.Id);

            Assert.That(model.IncomesCategories.CategoriesName.Count, Is.EqualTo(1));
            Assert.That(model.IncomesCategories.IncomesByCategoriesName.Count, Is.EqualTo(1));
        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
