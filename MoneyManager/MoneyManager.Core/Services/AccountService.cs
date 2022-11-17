using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repo;
        public AccountService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<AccountViewModel>> GetAllByUserIdAsync(string userId)
        {
            return await repo.AllReadonly<Account>().Where(x => x.ApplicationUserId == userId && x.IsActive).OrderBy(x => x.Name).Select(i => new AccountViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Name,
                ApplicationUserId = i.ApplicationUserId
            }).ToListAsync();
        }
        public async Task AddAccountAsync(AddAccountViewModel model, string userId)
        {

            var entity = new Account()
            {
                Amount = model.Amount,
                Name = model.Name,
                ApplicationUserId = userId
            };

            await repo.AddAsync(entity);

            await repo.SaveChangesAsync();

        }
        public async Task DeleteAsync(Guid id)
        {
            var account = await repo.GetByIdAsync<Account>(id);

            if (account != null)
            {
                account.IsActive = false;

                repo.Update<Account>(account);

                await repo.SaveChangesAsync();
            }
        }

        public async Task<EditAccountViewModel> GetForEditAsync(Guid id)
        {
            var account = await repo.GetByIdAsync<Account>(id);

            return new EditAccountViewModel()
            {
                Id = account.Id,
                Name = account.Name,
                Amount = account.Amount
            };
        }

        public async Task EditAsync(EditAccountViewModel model)
        {
            var entity = await repo.GetByIdAsync<Account>(model.Id);

            entity.Amount = model.Amount;
            entity.Name = model.Name;

            await repo.SaveChangesAsync();
        }
    }
}
