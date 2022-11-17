using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
