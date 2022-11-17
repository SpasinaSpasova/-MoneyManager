using System.ComponentModel.DataAnnotations;
using static MoneyManager.Infrastructure.Data.DataConstants.CategoryExpensesAndIncomes;

namespace MoneyManager.Core.Models.CategoryExpense
{
    public class AddCategoryExpenseViewModel
    {
        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
