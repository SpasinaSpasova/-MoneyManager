using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface IAccountService
    {
        Task<List<AccountViewModel>> GetAllByUserIdAsync(string userId);
    }
}
