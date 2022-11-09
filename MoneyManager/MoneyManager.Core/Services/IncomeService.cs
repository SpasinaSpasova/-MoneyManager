using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository repo;
        public IncomeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddIncomeAsync(AddIncomeViewModel model,string userId)
        {
            var entity = new Income()
            {
                Amount = model.Amount,
                Description = model.Description,
                Date = model.Date,
                Photo = model.Photo,
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
            return await repo.AllReadonly<Account>().Select(i => new AccountViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Name,
                ApplicationUserId = i.ApplicationUserId
            }).Where(x => x.ApplicationUserId == userId).ToListAsync();
        }

        public async Task<List<IncomeViewModel>> GetAllByUserIdAsync(string userId)
        {
            return await repo.AllReadonly<Income>().Select(i => new IncomeViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Description = i.Description,
                Date = i.Date,
                Photo = i.Photo,
                Category = i.Category.Name,
                Account = i.Account.Name,
                ApplicationUserId = i.ApplicationUserId
            }).Where(x => x.ApplicationUserId == userId).ToListAsync();
        }

        public async Task<List<CategoryIncome>> GetCategoriesIncomeAsync()
        {
            return await repo.AllReadonly<CategoryIncome>().ToListAsync();
        }

        private async Task IncrementAccountAmountAsync(Guid accountId,decimal increment)
        {
            var entity = await repo.GetByIdAsync<Account>(accountId);
            entity.Amount += increment;

             repo.Update<Account>(entity);

            await repo.SaveChangesAsync();
        }

    }
}
