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


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
