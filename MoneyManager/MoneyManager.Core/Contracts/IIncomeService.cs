using Microsoft.AspNetCore.Http;
using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.CategoryIncome;
using MoneyManager.Core.Models.Income;

namespace MoneyManager.Core.Contracts
{
    public interface IIncomeService
    {
        Task<List<IncomeViewModel>> GetAllByUserIdAsync(string userId);
        Task<List<CategoryIncomeViewModel>> GetCategoriesIncomeAsync();
        Task<List<AccountViewModel>> GetAccountsByIdAsync(string userId);
        Task AddIncomeAsync(AddIncomeViewModel model, string userId);
        Task DeleteAsync(Guid id);
        Task UploadAsync(Guid id, IFormFileCollection files);
        Task<EditIncomeViewModel> GetForEditAsync(Guid id);
        Task EditAsync(EditIncomeViewModel model);
    }
}
