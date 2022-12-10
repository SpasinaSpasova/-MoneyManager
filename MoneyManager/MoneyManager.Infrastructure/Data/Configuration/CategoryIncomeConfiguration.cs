using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    public class CategoryIncomeConfiguration : IEntityTypeConfiguration<CategoryIncome>
    {
        public void Configure(EntityTypeBuilder<CategoryIncome> builder)
        {
            //builder.HasData(CreateCategoriesIncomes());
        }

        //private List<CategoryIncome> CreateCategoriesIncomes()
        //{
        //    var categoryIncomes = new List<CategoryIncome>();

        //    var firstCategoryIncome = new CategoryIncome()
        //    {
        //        Id = new Guid("c6920210-3413-42e4-854c-cadd35517bbc"),
        //        Name = "Salary"
        //    };

        //    categoryIncomes.Add(firstCategoryIncome);

        //    var secondCategoryIncome = new CategoryIncome()
        //    {
        //        Id = new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
        //        Name = "Vouchers"
        //    };

        //    categoryIncomes.Add(secondCategoryIncome);

        //    var thirdCategoryIncome = new CategoryIncome()
        //    {
        //        Id = new Guid("01eeec85-4e1c-4838-ad16-b113c7afd03d"),
        //        Name = "Advance payment"
        //    };

        //    categoryIncomes.Add(thirdCategoryIncome);

        //    return categoryIncomes;
        //}
    }
}
