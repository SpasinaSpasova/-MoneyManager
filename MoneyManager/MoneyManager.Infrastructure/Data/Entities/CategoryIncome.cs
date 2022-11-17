using System.ComponentModel.DataAnnotations;
using static MoneyManager.Infrastructure.Data.DataConstants.CategoryExpensesAndIncomes;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class CategoryIncome
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
