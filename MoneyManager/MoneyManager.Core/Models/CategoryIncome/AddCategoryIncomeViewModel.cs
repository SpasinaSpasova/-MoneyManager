using System.ComponentModel.DataAnnotations;
using static MoneyManager.Infrastructure.Data.DataConstants.CategoryExpensesAndIncomes;

namespace MoneyManager.Core.Models.CategoryIncome
{
    public class AddCategoryIncomeViewModel
    {
        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
