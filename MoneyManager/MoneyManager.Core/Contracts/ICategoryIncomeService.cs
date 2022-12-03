using MoneyManager.Core.Models.CategoryIncome;

namespace MoneyManager.Core.Contracts
{
    public interface ICategoryIncomeService
    {
        Task<List<CategoryIncomeViewModel>> GetAllAsync();
        Task<bool> AddCategoryAsync(AddCategoryIncomeViewModel model);
        Task<EditCategoryIncomeViewModel> GetForEditAsync(Guid id);
        Task EditAsync(EditCategoryIncomeViewModel model);
        Task DeleteAsync(Guid id);
    }
}
