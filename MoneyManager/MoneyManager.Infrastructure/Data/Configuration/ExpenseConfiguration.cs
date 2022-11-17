using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasData(CreateExpenses());
        }

        private List<Expense> CreateExpenses()
        {
            var expenses = new List<Expense>();


            var fileName = "wwwroot/resources/gift-voucher.jpg";

            var photo = StreamFile(fileName);

            var firstExpense = new Expense()
            {
                Id = new Guid("a3dc14db-1461-4543-a291-5b0efb43db69"),
                Amount = 50.2m,
                Description = "Gift",
                Date = DateTime.Now.AddDays(2),
                CategoryId = new Guid("8cd4d9ba-f2b7-4fca-811e-2e83de454910"),
                AccountId = new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"),
                ApplicationUserId = "55098375-47e8-4589-816e-268d714f568b",
                Photo = photo
            };

            expenses.Add(firstExpense);

            return expenses;
        }
        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] ImageData = System.IO.File.ReadAllBytes(filename);

            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            return ImageData;
        }
    }
}
