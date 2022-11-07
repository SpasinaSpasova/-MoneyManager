using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeViewModel>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<CategoryIncome>> GetCategoriesIncomeAsync();
       // Task<IEnumerable<AccountViewModel>> GetAccountsByIdAsync(string userId);
    }
}
