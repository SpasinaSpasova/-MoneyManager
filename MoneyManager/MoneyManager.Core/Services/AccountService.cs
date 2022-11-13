using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await repo.AllReadonly<Account>().Where(x => x.IsActive).Select(i => new AccountViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Name = i.Name,
                ApplicationUserId = i.ApplicationUserId
            }).Where(x => x.ApplicationUserId == userId).ToListAsync();
        }
    }
}
