using MoneyManager.Core.Models.CategoryExpense;


namespace MoneyManager.Core.Contracts
{
    public interface ICategoryExpenseService
    {
        Task<List<CategoryExpenseViewModel>> GetAllAsync();
        Task<bool> AddCategoryAsync(AddCategoryExpenseViewModel model);
        Task<EditCategoryExpenseViewModel> GetForEditAsync(Guid id);
        Task<bool> EditAsync(EditCategoryExpenseViewModel model);
        Task DeleteAsync(Guid id);
    }
}
