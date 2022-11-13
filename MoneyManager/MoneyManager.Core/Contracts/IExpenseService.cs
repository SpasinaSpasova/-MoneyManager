using Microsoft.AspNetCore.Http;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.Expense;
using MoneyManager.Core.Models.Income;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface IExpenseService
    {
        Task<List<ExpenseViewModel>> GetAllByUserIdAsync(string userId);
        Task<List<CategoryExpense>> GetCategoriesExpenseAsync();
        Task<List<AccountViewModel>> GetAccountsByIdAsync(string userId);
        Task AddExpenseAsync(AddExpenseViewModel model, string userId);
        Task UploadAsync(Guid id, IFormFileCollection files);
        Task DeleteAsync(Guid id);
        Task<EditExpenseViewModel> GetForEditAsync(Guid id);
        Task<int> EditAsync(EditExpenseViewModel model);
    }
}
