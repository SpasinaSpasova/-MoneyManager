using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    public class CategoryExpenseConfiguration : IEntityTypeConfiguration<CategoryExpense>
    {
        public void Configure(EntityTypeBuilder<CategoryExpense> builder)
        {
            //builder.HasData(CreateCategoriesExpenses());
        }

        //private List<CategoryExpense> CreateCategoriesExpenses()
        //{
        //    var categoryExpenses = new List<CategoryExpense>();

        //    var firstCategoryExpense = new CategoryExpense()
        //    {
        //        Id = new Guid("2751e7ab-b8ea-4c50-b2a4-9bf7a600ce0d"),
        //        Name = "Food"
        //    };

        //    categoryExpenses.Add(firstCategoryExpense);

        //    var secondCategoryExpense = new CategoryExpense()
        //    {
        //        Id = new Guid("41e3fe82-74af-4c51-bed3-6026a559873a"),
        //        Name = "Transportation"
        //    };

        //    categoryExpenses.Add(secondCategoryExpense);

        //    var thirdCategoryExpense = new CategoryExpense()
        //    {
        //        Id = new Guid("8cd4d9ba-f2b7-4fca-811e-2e83de454910"),
        //        Name = "Gift"
        //    };

        //    categoryExpenses.Add(thirdCategoryExpense);

        //    return categoryExpenses;
        //}
    }
}
