using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasData(CreateIncomes());
        }

        private List<Income> CreateIncomes()
        {
            var incomes = new List<Income>();

            var firstIncome = new Income()
            {
                Id = new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
                Amount = 120.3m,
                Description = "Money gift for my birthday",
                Date = DateTime.Now.AddDays(7),
                CategoryId = new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
                AccountId = new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
                ApplicationUserId= "ce00c486-6a17-41da-804f-40a576cd020d"
            };

            incomes.Add(firstIncome);

            return incomes;
        }
    }
}
