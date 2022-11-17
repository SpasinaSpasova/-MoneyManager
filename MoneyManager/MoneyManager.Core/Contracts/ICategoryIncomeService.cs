using MoneyManager.Core.Models.Account;
using MoneyManager.Core.Models.CategoryIncome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface ICategoryIncomeService
    {
        Task<List<CategoryIncomeViewModel>> GetAllAsync();
        Task AddCategoryAsync(AddCategoryIncomeViewModel model);
        Task<EditCategoryIncomeViewModel> GetForEditAsync(Guid id);
        Task EditAsync(EditCategoryIncomeViewModel model);
    }
}
