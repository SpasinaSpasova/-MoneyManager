using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<IncomeViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Income>().Select(i => new IncomeViewModel()
            {
                Id = i.Id,
                Amount = i.Amount,
                Description = i.Description,
                Date = i.Date,
                Photo = i.Photo,
                Category = i.Category.Name,
                Account = i.Account.Name
            }).ToListAsync();
        }
    }
}
