using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Infrastructure.Data.Common;
using MoneyManager.Infrastructure.Data;
using MoneyManager.Core.Services;
using MoneyManager.Infrastructure.Data.Entities;
using MoneyManager.Core.Models.CategoryExpense;

namespace MoneyManager.UnitTests
{
    [TestFixture]
    public class CategoryExpenseTests
    {
        private IRepository _repo;
        private ICategoryExpenseService categoryExpenseService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("CategoryExpenseDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }


        [Test]
        public async Task GetAllCategoryExpenses()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                },
                 new CategoryExpense() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat3"
                 }
            });

            await repo.SaveChangesAsync();

            var categories = await categoryExpenseService.GetAllAsync();

            Assert.That(categories.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllCategoryExpensesOnlyActive()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                },
                 new CategoryExpense() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat3",
                    IsActive=false
                }
            });

            await repo.SaveChangesAsync();

            var categories = await categoryExpenseService.GetAllAsync();

            Assert.That(categories.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddCategoryAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                }
            });

            await repo.SaveChangesAsync();

            AddCategoryExpenseViewModel category = new AddCategoryExpenseViewModel()
            {
                Name = "cat3"
            };

            var IsSuccess = await categoryExpenseService.AddCategoryAsync(category);

            Assert.That(IsSuccess, Is.True);
        }

        [Test]
        public async Task AddCategoryAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                }
            });

            await repo.SaveChangesAsync();

            AddCategoryExpenseViewModel category = new AddCategoryExpenseViewModel()
            {
                Name = "cat2"
            };

            var IsSuccess = await categoryExpenseService.AddCategoryAsync(category);

            Assert.That(IsSuccess, Is.False);
        }

        [Test]
        public async Task DeleteCategoryAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);

            CategoryExpense category = new CategoryExpense()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryExpense>(category);

            await repo.SaveChangesAsync();

            await categoryExpenseService.DeleteAsync(category.Id);

            Assert.That(category.IsActive, Is.False);
        }

        [Test]
        public async Task DeleteCategoryAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);


            CategoryExpense category = new CategoryExpense()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryExpense>(category);

            await repo.SaveChangesAsync();

            await categoryExpenseService.DeleteAsync(new Guid("d5527a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(repo.AllReadonly<CategoryExpense>().Where(x => x.IsActive).Count<CategoryExpense>(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetForEditAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);


            CategoryExpense category = new CategoryExpense()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryExpense>(category);

            await repo.SaveChangesAsync();

            EditCategoryExpenseViewModel cat = await categoryExpenseService.GetForEditAsync(new Guid("d5527a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(cat.Id, Is.EqualTo(new Guid()));
        }

        [Test]
        public async Task GetForEditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);


            CategoryExpense category = new CategoryExpense()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryExpense>(category);

            await repo.SaveChangesAsync();

            EditCategoryExpenseViewModel cat = await categoryExpenseService.GetForEditAsync(category.Id);

            Assert.That(cat.Id, Is.EqualTo(category.Id));
            Assert.That(cat.Name, Is.EqualTo(category.Name));
        }

        [Test]
        public async Task EditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryExpenseService = new CategoryExpenseService(repo);


            CategoryExpense category = new CategoryExpense()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryExpense>(category);

            await repo.SaveChangesAsync();

            EditCategoryExpenseViewModel cat = new EditCategoryExpenseViewModel()
            {
                Id = category.Id,
                Name = "catEdit"
            };

            await categoryExpenseService.EditAsync(cat);

            Assert.That(category.Name, Is.EqualTo(cat.Name));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
