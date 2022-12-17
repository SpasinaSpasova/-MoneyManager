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
using MoneyManager.Core.Models.Account;

namespace MoneyManager.UnitTests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IRepository _repo;
        private IAccountService accountService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("AccountDB")
               .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task GetAllAccountsByCurrentUser()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            await repo.AddRangeAsync(new List<Account>()
            {
                new Account() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="account1",
                    Amount = 50.20m,
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                    ApplicationUserId=  "ab110557-1dfa-4db5-8d63-e24cbf87ff2d"
                },
                new Account() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 63.20m ,
                    Name="account2",
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f"
                },
                 new Account() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 33.99m ,
                    Name="account3",
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f"
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var accounts = await accountService.GetAllByUserIdAsync(userId);

            Assert.That(accounts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAccountsByCurrentUserOnlyActive()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            await repo.AddRangeAsync(new List<Account>()
            {
                new Account() {
                    Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                    Name="account1",
                    Amount = 50.20m,
                    ApplicationUser= new ApplicationUser() { Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d", FirstName ="user1",LastName="user1" },
                    ApplicationUserId=  "ab110557-1dfa-4db5-8d63-e24cbf87ff2d"
                },
                new Account() {
                    Id = new Guid("6c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 63.20m ,
                    Name="account2",
                    ApplicationUser= new ApplicationUser() { Id = "ab7803cf-824e-4abc-b3fe-a88815025e5f", FirstName ="user2",LastName="user2" },
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f"
                },
                 new Account() {
                    Id = new Guid("8c08608b-b2d1-4aaf-82a8-756286e2df21"),
                    Amount = 33.99m ,
                    Name="account3",
                    ApplicationUserId= "ab7803cf-824e-4abc-b3fe-a88815025e5f",
                    IsActive=false
                }
            });

            await repo.SaveChangesAsync();

            string userId = "ab7803cf-824e-4abc-b3fe-a88815025e5f";

            var accounts = await accountService.GetAllByUserIdAsync(userId);

            Assert.That(accounts.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AddAccountAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<ApplicationUser>(user);
            await repo.AddAsync<Account>(account);
            await repo.SaveChangesAsync();

            AddAccountViewModel accountVM = new AddAccountViewModel()
            {
                Name = "addAccount",
                Amount = 50
            };

            var isSuccess = await accountService.AddAccountAsync(accountVM,user.Id);

            Assert.That(isSuccess, Is.False);
        }

        [Test]
        public async Task AddAccountAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };


            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            AddAccountViewModel accountVM = new AddAccountViewModel()
            {
                Name = "addAccount",
                Amount = 50
            };

            var isSuccess = await accountService.AddAccountAsync(accountVM, user.Id);

            Assert.That(isSuccess, Is.True);
            Assert.That(repo.AllReadonly<Account>().Count<Account>(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAccountAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            await accountService.DeleteAsync(account.Id);

            Assert.That(account.IsActive, Is.False);
        }

        [Test]
        public async Task DeleteAccountAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            await accountService.DeleteAsync(new Guid("e2427a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(repo.AllReadonly<Account>().Where(x=>x.IsActive).Count<Account>(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetForEditAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

           EditAccountViewModel edit= await accountService.GetForEditAsync(new Guid("e2427a8d-2d33-475c-9f60-dfb40a76a854"));

            Assert.That(edit.Id, Is.EqualTo(new Guid()));
        }

        [Test]
        public async Task GetForEditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            EditAccountViewModel edit = await accountService.GetForEditAsync(account.Id);

            Assert.That(edit.Id, Is.EqualTo(account.Id));
            Assert.That(edit.Name, Is.EqualTo(account.Name));
            Assert.That(edit.Amount, Is.EqualTo(account.Amount));
        }

        [Test]
        public async Task EditAsyncSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            EditAccountViewModel edit = new EditAccountViewModel()
            {
                Id=account.Id,
                Name = "edited",
                Amount = 10
            };

           await accountService.EditAsync(edit,user.Id);

            Assert.That(account.Name, Is.EqualTo(edit.Name));
            Assert.That(account.Amount, Is.EqualTo(edit.Amount));
        }

        [Test]
        public async Task EditAsyncNotSuccess()
        {
            var repo = new Repository(applicationDbContext);
            accountService = new AccountService(repo);

            ApplicationUser user = new ApplicationUser()
            {
                Id = "ab110557-1dfa-4db5-8d63-e24cbf87ff2d",
                FirstName = "user1",
                LastName = "user1"
            };

            Account account = new Account()
            {
                Id = new Guid("e2627a8d-2d33-475c-9f60-dfb40a76a854"),
                Name = "addAccount",
                Amount = 50.20m,
                ApplicationUserId = user.Id
            };

            await repo.AddAsync<Account>(account);
            await repo.AddAsync<ApplicationUser>(user);
            await repo.SaveChangesAsync();

            EditAccountViewModel edit = new EditAccountViewModel()
            {
                Id = account.Id,
                Name = "AddAccount",
                Amount = 10
            };

           var result= await accountService.EditAsync(edit, user.Id);

            Assert.That(result, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
