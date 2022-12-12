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
using MoneyManager.Core.Models.Income;
using MoneyManager.Core.Models.Expense;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;

namespace MoneyManager.UnitTests
{
    [TestFixture]
    public class ExpenseServiceTests
    {
        private IRepository _repo;
        private IExpenseService expenseService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("ExpenseDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task GetExpensesByCurrentUser()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<Expense>()
            {
                new Expense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Amount = 50.20m,
                    Date = DateTime.UtcNow.AddDays(2),
                    Category=new CategoryExpense() { Id = new Guid("4cf3dab7-deab-4785-89c9-ef0addaff70a"), Name ="Cat1"  },
                    CategoryId = new Guid("4cf3dab7-deab-4785-89c9-ef0addaff70a") ,
                    AccountId= new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                    Account= new Account() { Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"), Name ="Account1",ApplicationUserId="ab110557-1dfa-4db5-8d63-e24cbf87ff2d", Amount = 50.20m },
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                    ApplicationUserId=  "ab110557-1dfa-4db5-8d63-e24cbf87ff2d"
                },
                new Expense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 63.20m ,
                    Date =  DateTime.UtcNow,
                    Category=new CategoryExpense() { Id = new Guid("270ffe2f-07bf-4661-9da5-f20179feea20"), Name ="Cat2"  },
                    CategoryId = new Guid("270ffe2f-07bf-4661-9da5-f20179feea20"),
                    Account= new Account() { Id = new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"), Name ="Account2",ApplicationUserId="ab7803cf-824e-4abc-b3fe-a88815025e5f", Amount = 50.20m },
                    AccountId= new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"),
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f"
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var expenses = await expenseService.GetAllByUserIdAsync(userId);

            Assert.That(expenses.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllExpensesByCurrentUserOnlyActiveIncomes()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<Expense>()
            {
                new Expense() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Amount = 50.20m,
                    Date = DateTime.UtcNow.AddDays(2),
                    Category=new CategoryExpense() { Id = new Guid("4cf3dab7-deab-4785-89c9-ef0addaff70a"), Name ="Cat1"  },
                    CategoryId = new Guid("4cf3dab7-deab-4785-89c9-ef0addaff70a") ,
                    AccountId= new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                    Account= new Account() { Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"), Name ="Account1",ApplicationUserId="ab110557-1dfa-4db5-8d63-e24cbf87ff2d", Amount = 50.20m },
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                    ApplicationUserId=  "ab110557-1dfa-4db5-8d63-e24cbf87ff2d"
                },
                new Expense() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 63.20m ,
                    Date =  DateTime.UtcNow,
                    Category=new CategoryExpense() { Id = new Guid("270ffe2f-07bf-4661-9da5-f20179feea20"), Name ="Cat2"  },
                    CategoryId = new Guid("270ffe2f-07bf-4661-9da5-f20179feea20"),
                    Account= new Account() { Id = new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"), Name ="Account2",ApplicationUserId="ab7803cf-824e-4abc-b3fe-a88815025e5f", Amount = 50.20m },
                    AccountId= new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"),
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f",
                    IsActive=false
                },
                 new Expense() {
                    Id = new Guid("50024280-deb8-4f01-9b30-37ea7d7b5429"),
                    Amount = 63.20m ,
                    Date =  DateTime.UtcNow,
                    Category=new CategoryExpense() { Id = new Guid("e68dcd73-7134-4706-9768-2b8eec3b9ff0"), Name ="Cat2"  },
                    CategoryId = new Guid("e68dcd73-7134-4706-9768-2b8eec3b9ff0"),
                    Account= new Account() { Id = new Guid("5366c28a-8f6b-4a51-a64b-47e474b53eaa"), Name ="Account2",ApplicationUserId="ab7803cf-824e-4abc-b3fe-a88815025e5f" , Amount = 50.20m},
                    AccountId= new Guid("5366c28a-8f6b-4a51-a64b-47e474b53eaa"),
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f",
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var expenses = await expenseService.GetAllByUserIdAsync(userId);

            Assert.That(expenses.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllAccountsByCurrentUser()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<Account>()
            {
                new Account() {
                    Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                    Amount = 50.20m,
                    Name ="Account1",
                    ApplicationUserId="ab110557-1dfa-4db5-8d63-e24cbf87ff2d" ,
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                },
                new Account() {
                    Id = new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"),
                    Amount = 63.20m ,
                    Name ="Account2",
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f"
                },
                 new Account() {
                    Id = new Guid("5366c28a-8f6b-4a51-a64b-47e474b53eaa"),
                    Amount = 63.20m ,
                    Name ="Account3",
                    ApplicationUserId="ab7803cf-824e-4abc-b3fe-a88815025e5f"
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var accounts = await expenseService.GetAccountsByIdAsync(userId);

            Assert.That(accounts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAccountsByCurrentUserOnlyActive()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<Account>()
            {
                new Account() {
                    Id = new Guid("25c81ad4-b580-43e9-a4b8-111e19053283"),
                    Amount = 50.20m,
                    Name ="Account1",
                    ApplicationUserId="ab110557-1dfa-4db5-8d63-e24cbf87ff2d" ,
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                },
                new Account() {
                    Id = new Guid("6334651f-a8a3-4d91-91f8-4c12dff46d0a"),
                    Amount = 63.20m ,
                    Name ="Account2",
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f",
                    IsActive=false
                },
                 new Account() {
                    Id = new Guid("5366c28a-8f6b-4a51-a64b-47e474b53eaa"),
                    Amount = 63.20m ,
                    Name ="Account3",
                    ApplicationUserId="ab7803cf-824e-4abc-b3fe-a88815025e5f"
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var accounts = await expenseService.GetAccountsByIdAsync(userId);

            Assert.That(accounts.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetCategoriesExpenseAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("948319ba-59a4-488d-a327-29ffb212bbbb"),
                    Name ="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("2aa57f59-21ef-4766-b0a3-b57aa62e25e4"),
                    Name ="cat2"
                },
                new CategoryExpense() {
                    Id = new Guid("9b9a5ef1-79e1-4f04-b288-9863c773e613"),
                    Name ="cat3"
                },

            });

            await repo.SaveChangesAsync();

            var categories = await expenseService.GetCategoriesExpenseAsync();

            Assert.That(categories.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetCategoriesIncomeAsyncOnlyActive()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await repo.AddRangeAsync(new List<CategoryExpense>()
            {
                new CategoryExpense() {
                    Id = new Guid("948319ba-59a4-488d-a327-29ffb212bbbb"),
                    Name ="cat1"
                },
                new CategoryExpense() {
                    Id = new Guid("2aa57f59-21ef-4766-b0a3-b57aa62e25e4"),
                    Name ="cat2"
                },
                new CategoryExpense() {
                    Id = new Guid("9b9a5ef1-79e1-4f04-b288-9863c773e613"),
                    Name ="cat3",
                    IsActive=false
                },

            });

            await repo.SaveChangesAsync();

            var categories = await expenseService.GetCategoriesExpenseAsync();

            Assert.That(categories.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddExpenseAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            AddExpenseViewModel expenseVM = new AddExpenseViewModel()
            {
                Amount = 20,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = account.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.SaveChangesAsync();

           var result= await expenseService.AddExpenseAsync(expenseVM, user.Id);

            Assert.That(repo.AllReadonly<Expense>().Count<Expense>(), Is.EqualTo(1));

            Assert.That(account.Amount, Is.EqualTo(30.20));

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AddExpenseAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            AddExpenseViewModel expenseVM = new AddExpenseViewModel()
            {
                Amount = 60,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = account.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.SaveChangesAsync();

            var result = await expenseService.AddExpenseAsync(expenseVM, user.Id);

            Assert.That(repo.AllReadonly<Expense>().Count<Expense>(), Is.EqualTo(0));

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AddExpenseAsyncNotSuccess_2()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            AddExpenseViewModel expenseVM = new AddExpenseViewModel()
            {
                Amount = 60,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = new Guid("85c81ad4-b580-43e9-a4b8-111e19053283")
            };

            await repo.AddAsync<Account>(account);
            await repo.SaveChangesAsync();

            var result = await expenseService.AddExpenseAsync(expenseVM, user.Id);

            Assert.That(repo.AllReadonly<Expense>().Count<Expense>(), Is.EqualTo(0));

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DeleteExpenseAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            await expenseService.DeleteAsync(expense.Id);

            Assert.That(repo.AllReadonly<Expense>().Where(x => x.IsActive).Count<Expense>(), Is.EqualTo(0));
            Assert.That(expense.IsActive, Is.False);
            Assert.That(account.Amount, Is.EqualTo(70.20));
        }

        [Test]
        public async Task DeleteExpenseAsyncNot()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

            await expenseService.DeleteAsync(new Guid("f2712406-43b4-46df-90be-933e106fb91c"));

            Assert.That(repo.AllReadonly<Expense>().Where(x => x.IsActive).Count<Expense>(), Is.EqualTo(0));

        }

        [Test]
        public async Task GetForEditAsyncEmptyViewModel()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = await expenseService.GetForEditAsync(new Guid("9957baa8-eabd-40ff-85b5-24ee7f62d805"));

            Assert.That(editVM.Id, Is.EqualTo(new Guid()));
        }

        [Test]
        public async Task GetForEditAsyncCorrectViewModel()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = await expenseService.GetForEditAsync(expense.Id);

            Assert.That(editVM.Id, Is.EqualTo(expense.Id));
            Assert.That(editVM.AccountId, Is.EqualTo(expense.AccountId));
            Assert.That(editVM.CategoryId, Is.EqualTo(expense.CategoryId));
            Assert.That(editVM.Description, Is.EqualTo(expense.Description));
            Assert.That(editVM.Amount, Is.EqualTo(expense.Amount));
            Assert.That(editVM.Date, Is.EqualTo(expense.Date));

        }

        [Test]
        public async Task UploadImageToExpenseAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            IFormFileCollection files = new FormFileCollection();

            await expenseService.UploadAsync(expense.Id, files);

            Assert.That(expense.Photo, Is.Null);

        }

        [Test]
        public async Task EditExpenseAmountAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = 10,
                Description = "test",
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = account.Id,
            };

            await expenseService.EditAsync(editVM);

            Assert.That(account.Amount, Is.EqualTo(60.20));
            Assert.That(expense.Amount, Is.EqualTo(10));
        }

        [Test]
        public async Task EditExpenseWithNoChangesAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = account.Id,
            };

            await expenseService.EditAsync(editVM);

            Assert.That(account.Amount, Is.EqualTo(50.20));
            Assert.That(expense.Amount, Is.EqualTo(20));
            Assert.That(expense.Description, Is.EqualTo("test"));
            Assert.That(expense.CategoryId, Is.EqualTo(new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0")));
            Assert.That(expense.AccountId, Is.EqualTo(account.Id));
        }

        [Test]
        public async Task EditExpenseAccountAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Account accountEdit = new Account()
            {
                Id = new Guid("0289df0e-44de-4a17-a805-93d5e97bb88e"),
                Amount = 30,
                Name = "AccountEdit",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Account>(accountEdit);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = accountEdit.Id,
            };

            await expenseService.EditAsync(editVM);

            Assert.That(account.Amount, Is.EqualTo(70.20));
            Assert.That(accountEdit.Amount, Is.EqualTo(10));

        }

        [Test]
        public async Task EditExpenseAccountAndAmountAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Account accountEdit = new Account()
            {
                Id = new Guid("0289df0e-44de-4a17-a805-93d5e97bb88e"),
                Amount = 30,
                Name = "AccountEdit",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Account>(accountEdit);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = 10,
                Description = expense.Description,
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = accountEdit.Id,
            };

            await expenseService.EditAsync(editVM);

            Assert.That(account.Amount, Is.EqualTo(70.20));
            Assert.That(accountEdit.Amount, Is.EqualTo(20));
            Assert.That(expense.Amount, Is.EqualTo(10));

        }

        [Test]
        public async Task EditExpenseNoEnoughAccountAmmountAsync()
        {
            var repo = new Repository(applicationDbContext);
            expenseService = new ExpenseService(repo);

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

            Account accountEdit = new Account()
            {
                Id = new Guid("0289df0e-44de-4a17-a805-93d5e97bb88e"),
                Amount = 30,
                Name = "AccountEdit",
                ApplicationUserId = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                ApplicationUser = user
            };

            Expense expense = new Expense()
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

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<Account>(accountEdit);
            await repo.AddAsync<Expense>(expense);
            await repo.SaveChangesAsync();

            EditExpenseViewModel editVM = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = 40,
                Description = expense.Description,
                Date = DateTime.UtcNow,
                CategoryId = new Guid("302837e6-5dbc-4d24-ba17-8815c119c7e0"),
                AccountId = accountEdit.Id,
            };

            var result = await expenseService.EditAsync(editVM);

            Assert.That(result, Is.False);

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
