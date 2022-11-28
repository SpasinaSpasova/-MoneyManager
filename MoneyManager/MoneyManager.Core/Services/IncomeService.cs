using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.CategoryIncome;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using Account = MoneyManager.Infrastructure.Data.Entities.Account;

namespace MoneyManager.Core.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository repo;
        public IncomeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddIncomeAsync(AddIncomeViewModel model, string userId)
        {
            var entity = new Income()
            {
                Amount = model.Amount,
                Description = model.Description,
                Date = model.Date,
                ApplicationUserId = userId,
                CategoryId = model.CategoryId,
                AccountId = model.AccountId
            };

            await repo.AddAsync(entity);

            await IncrementAccountAmountAsync(model.AccountId, model.Amount);

            await repo.SaveChangesAsync();
        }

        public async Task<List<AccountViewModel>> GetAccountsByIdAsync(string userId)
        {
            return await repo.AllReadonly<Account>().Where(x => x.ApplicationUserId == userId && x.IsActive).OrderBy(x => x.Name).Select(i => new AccountViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Name,
                ApplicationUserId = i.ApplicationUserId
            }).ToListAsync();
        }

        public async Task<List<IncomeViewModel>> GetAllByUserIdAsync(string userId)
        {
            return await repo.AllReadonly<Income>().Where(x => x.ApplicationUserId == userId && x.IsActive).OrderByDescending(x => x.Date).Select(i => new IncomeViewModel()
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

        public async Task<List<CategoryIncomeViewModel>> GetCategoriesIncomeAsync()
        {
            return await repo.AllReadonly<CategoryIncome>().OrderBy(x => x.Name).Select(c => new CategoryIncomeViewModel()
            {
                Id = c.Id,
                Name = c.Name

            }).ToListAsync();
        }

        private async Task IncrementAccountAmountAsync(Guid accountId, decimal increment)
        {
            var entity = await repo.GetByIdAsync<Account>(accountId);
            entity.Amount += increment;

            repo.Update<Account>(entity);

            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var income = await repo.GetByIdAsync<Income>(id);
            if (income != null)
            {
                income.IsActive = false;

                var account = await repo.GetByIdAsync<Account>(income.AccountId);
                account.Amount -= income.Amount;

                repo.Update<Account>(account);

                await repo.SaveChangesAsync();
            }
        }

        public async Task UploadAsync(Guid id, IFormFileCollection files)
        {
            var entity = await repo.GetByIdAsync<Income>(id);

            foreach (var file in files)
            {
                string fileName = file.FileName;

                using (MemoryStream ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    byte[] data = ms.ToArray();

                    entity.Photo = data;

                    repo.Update<Income>(entity);

                    await repo.SaveChangesAsync();
                }
            }
        }

        public async Task<EditIncomeViewModel> GetForEditAsync(Guid id)
        {
            var income = await repo.GetByIdAsync<Income>(id);

            return new EditIncomeViewModel()
            {
                Id = income.Id,
                Amount = income.Amount,
                Description = income.Description,
                AccountId = income.AccountId,
                CategoryId = income.CategoryId,
                Date = income.Date
            };


        }

        public async Task EditAsync(EditIncomeViewModel model)
        {
            var entity = await repo.GetByIdAsync<Income>(model.Id);
            var account = await repo.GetByIdAsync<Account>(entity.AccountId);

            if (entity.AccountId != model.AccountId && entity.Amount != model.Amount)
            {
                var newAccount = await repo.GetByIdAsync<Account>(model.AccountId);
                newAccount.Amount += model.Amount;
                account.Amount -= entity.Amount;
                repo.Update<Account>(account);
                repo.Update<Account>(newAccount);
            }
            else if (entity.AccountId != model.AccountId)
            {
                var newAccount = await repo.GetByIdAsync<Account>(model.AccountId);
                newAccount.Amount += model.Amount;
                account.Amount -= entity.Amount;
                repo.Update<Account>(account);
                repo.Update<Account>(newAccount);
            }
            else if (entity.Amount != model.Amount)
            {
                account.Amount -= entity.Amount;
                account.Amount += model.Amount;
                repo.Update<Account>(account);
            }

            entity.Amount = model.Amount;
            entity.AccountId = model.AccountId;
            entity.Description = model.Description;
            entity.Date = model.Date;
            entity.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }
    }
}
