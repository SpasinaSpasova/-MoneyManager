using Microsoft.AspNetCore.Http;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.CategoryExpense;
using MoneyManager.Core.Models.Expense;

namespace MoneyManager.Core.Contracts
{
    public interface IExpenseService
    {
        Task<List<ExpenseViewModel>> GetAllByUserIdAsync(string userId);
        Task<List<CategoryExpenseViewModel>> GetCategoriesExpenseAsync();
        Task<List<AccountViewModel>> GetAccountsByIdAsync(string userId);
        Task<bool> AddExpenseAsync(AddExpenseViewModel model, string userId);
        Task UploadAsync(Guid id, IFormFileCollection files);
        Task DeleteAsync(Guid id);
        Task<EditExpenseViewModel> GetForEditAsync(Guid id);
        Task<bool> EditAsync(EditExpenseViewModel model);
    }
}
