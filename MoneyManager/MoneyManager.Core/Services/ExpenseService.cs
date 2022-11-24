using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.CategoryExpense;
using MoneyManager.Core.Models.Expense;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository repo;
        public ExpenseService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> AddExpenseAsync(AddExpenseViewModel model, string userId)
        {
            var account =  repo.AllReadonly<Account>().FirstOrDefault(x => x.Id == model.AccountId);

            if (account != null)
            {
               
                if (account.Amount>=model.Amount)
                {
                    var entity = new Expense()
                    {
                        Amount = model.Amount,
                        Description = model.Description,
                        Date = model.Date,
                        ApplicationUserId = userId,
                        CategoryId = model.CategoryId,
                        AccountId = model.AccountId
                    };

                    await repo.AddAsync(entity);

                    await DecrementAccountAmountAsync(model.AccountId, model.Amount);

                    await repo.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task<List<AccountViewModel>> GetAccountsByIdAsync(string userId)
        {
            return await repo.AllReadonly<Account>().Where(x => x.ApplicationUserId == userId && x.IsActive && x.Amount > 0).OrderBy(x => x.Name).Select(i => new AccountViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Name,
                ApplicationUserId = i.ApplicationUserId
            }).ToListAsync();
        }

        public async Task<List<ExpenseViewModel>> GetAllByUserIdAsync(string userId)
        {
            return await repo.AllReadonly<Expense>().Where(x => x.ApplicationUserId == userId && x.IsActive).OrderByDescending(x => x.Date).Select(i => new ExpenseViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Description = i.Description,
                Date = i.Date,
                Photo = i.Photo,
                Category = i.Category.Name,
                Account = i.Account.Name,
                ApplicationUserId = i.ApplicationUserId
            }).ToListAsync();
        }

        public async Task<List<CategoryExpenseViewModel>> GetCategoriesExpenseAsync()
        {
            return await repo.AllReadonly<CategoryExpense>().OrderBy(x => x.Name).Select(x => new CategoryExpenseViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task UploadAsync(Guid id, IFormFileCollection files)
        {
            var entity = await repo.GetByIdAsync<Expense>(id);

            foreach (var file in files)
            {
                string fileName = file.FileName;

                using (MemoryStream ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    byte[] data = ms.ToArray();

                    entity.Photo = data;

                    repo.Update<Expense>(entity);

                    await repo.SaveChangesAsync();
                }
            }
        }


        public async Task DeleteAsync(Guid id)
        {
            var expense = await repo.GetByIdAsync<Expense>(id);
            if (expense != null)
            {
                expense.IsActive = false;

                var account = await repo.GetByIdAsync<Account>(expense.AccountId);
                account.Amount += expense.Amount;

                repo.Update<Account>(account);

                await repo.SaveChangesAsync();
            }
        }

        public async Task<EditExpenseViewModel> GetForEditAsync(Guid id)
        {
            var expense = await repo.GetByIdAsync<Expense>(id);

            return new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                AccountId = expense.AccountId,
                CategoryId = expense.CategoryId,
                Date = expense.Date
            };
        }

        public async Task<bool> EditAsync(EditExpenseViewModel model)
        {
            var entity = await repo.GetByIdAsync<Expense>(model.Id);
            var account = await repo.GetByIdAsync<Account>(entity.AccountId);
            var newAccount = await repo.GetByIdAsync<Account>(model.AccountId);

            if ((entity.Amount != model.Amount
                && account.Amount < model.Amount) || (entity.Amount != model.Amount
                && newAccount.Amount < model.Amount))
            {
                return false;
            }

            if (entity.AccountId != model.AccountId && entity.Amount != model.Amount)
            {
                newAccount.Amount -= model.Amount;
                account.Amount += entity.Amount;
                repo.Update<Account>(account);
                repo.Update<Account>(newAccount);
            }
            else if (entity.AccountId != model.AccountId)
            {
                newAccount.Amount -= model.Amount;
                account.Amount += entity.Amount;
                repo.Update<Account>(account);
                repo.Update<Account>(newAccount);
            }
            else if (entity.Amount != model.Amount)
            {
                account.Amount += entity.Amount;
                account.Amount -= model.Amount;
                repo.Update<Account>(account);
            }

            entity.Amount = model.Amount;
            entity.AccountId = model.AccountId;
            entity.Description = model.Description;
            entity.Date = model.Date;
            entity.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();

            return true;
        }
        private async Task DecrementAccountAmountAsync(Guid accountId, decimal decrement)
        {
            var entity = await repo.GetByIdAsync<Account>(accountId);
            entity.Amount -= decrement;

            repo.Update<Account>(entity);

            await repo.SaveChangesAsync();
        }
    }
}
