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
using MoneyManager.Core.Models.CategoryIncome;

namespace MoneyManager.UnitTests
{
    [TestFixture]
    public class CategoryIncomeTest
    {
        private IRepository _repo;
        private ICategoryIncomeService categoryIncomeService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("CategoryIncomeDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task GetAllCategoryIncomes()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);

            await repo.AddRangeAsync(new List<CategoryIncome>()
            {
                new CategoryIncome() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryIncome() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                },
                 new CategoryIncome() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat3"
                }
            });

            await repo.SaveChangesAsync();

            var categories = await categoryIncomeService.GetAllAsync();

            Assert.That(categories.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllCategoryIncomesOnlyActive()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);

            await repo.AddRangeAsync(new List<CategoryIncome>()
            {
                new CategoryIncome() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryIncome() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                },
                 new CategoryIncome() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat3",
                    IsActive=false
                }
            });

            await repo.SaveChangesAsync();

            var categories = await categoryIncomeService.GetAllAsync();

            Assert.That(categories.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddCategoryAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);

            await repo.AddRangeAsync(new List<CategoryIncome>()
            {
                new CategoryIncome() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryIncome() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                }
            });

            await repo.SaveChangesAsync();

            AddCategoryIncomeViewModel category = new AddCategoryIncomeViewModel()
            {
                Name = "cat3"
            };

            var IsSuccess = await categoryIncomeService.AddCategoryAsync(category);

            Assert.That(IsSuccess, Is.True);
        }

        [Test]
        public async Task AddCategoryAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);

            await repo.AddRangeAsync(new List<CategoryIncome>()
            {
                new CategoryIncome() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="cat1"
                },
                new CategoryIncome() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Name="cat2"
                }
            });

            await repo.SaveChangesAsync();

            AddCategoryIncomeViewModel category = new AddCategoryIncomeViewModel()
            {
                Name = "cat2"
            };

            var IsSuccess = await categoryIncomeService.AddCategoryAsync(category);

            Assert.That(IsSuccess, Is.False);
        }

        [Test]
        public async Task DeleteCategoryAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);


            CategoryIncome category = new CategoryIncome()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

           await repo.AddAsync<CategoryIncome>(category);

            await repo.SaveChangesAsync();

            await categoryIncomeService.DeleteAsync(category.Id);

            Assert.That(category.IsActive, Is.False);
        }

        [Test]
        public async Task DeleteCategoryAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);


            CategoryIncome category = new CategoryIncome()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryIncome>(category);

            await repo.SaveChangesAsync();

            await categoryIncomeService.DeleteAsync(new Guid("d5527a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(repo.AllReadonly<CategoryIncome>().Where(x => x.IsActive).Count<CategoryIncome>(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetForEditAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);


            CategoryIncome category = new CategoryIncome()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryIncome>(category);

            await repo.SaveChangesAsync();

            EditCategoryIncomeViewModel cat= await categoryIncomeService.GetForEditAsync(new Guid("d5527a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(cat.Id, Is.EqualTo(new Guid()));
        }

        [Test]
        public async Task GetForEditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);


            CategoryIncome category = new CategoryIncome()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryIncome>(category);

            await repo.SaveChangesAsync();

            EditCategoryIncomeViewModel cat = await categoryIncomeService.GetForEditAsync(category.Id);

            Assert.That(cat.Id, Is.EqualTo(category.Id));
            Assert.That(cat.Name, Is.EqualTo(category.Name));
        }

        [Test]
        public async Task EditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            categoryIncomeService = new CategoryIncomeService(repo);


            CategoryIncome category = new CategoryIncome()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "cat1"
            };

            await repo.AddAsync<CategoryIncome>(category);

            await repo.SaveChangesAsync();

            EditCategoryIncomeViewModel cat = new EditCategoryIncomeViewModel()
            {
                Id = category.Id,
                Name = "catEdit"
            };

            await categoryIncomeService.EditAsync(cat);

            Assert.That(category.Name, Is.EqualTo(cat.Name));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
