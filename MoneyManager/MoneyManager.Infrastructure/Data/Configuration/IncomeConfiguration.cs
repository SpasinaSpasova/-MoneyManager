using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
           // builder.HasData(CreateIncomes());
        }

        //private List<Income> CreateIncomes()
        //{
        //    var incomes = new List<Income>();

        //    var fileName = "wwwroot/resources/gift-voucher.jpg";

        //    var photo = StreamFile(fileName);

        //    var firstIncome = new Income()
        //    {
        //        Id = new Guid("550dce86-3221-4f10-85c8-f563ce873798"),
        //        Amount = 120,
        //        Description = "Money gift for my birthday",
        //        Date = DateTime.Now.AddDays(7),
        //        CategoryId = new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
        //        AccountId = new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
        //        ApplicationUserId= "ce00c486-6a17-41da-804f-40a576cd020d",
        //        Photo=photo
        //    };

        //    incomes.Add(firstIncome);

        //    var secondIncome = new Income()
        //    {
        //        Id = new Guid("27ff74fc-1509-4807-b776-b95fe7ae73d6"),
        //        Amount = 120,
        //        Description = "Money gift for my birthday",
        //        Date = DateTime.Now.AddDays(7),
        //        CategoryId = new Guid("11a9d1a1-7153-4609-96bb-abc83181ab30"),
        //        AccountId = new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"),
        //        ApplicationUserId = "55098375-47e8-4589-816e-268d714f568b",
        //        Photo = photo
        //    };

        //    incomes.Add(secondIncome);

        //    return incomes;
        //}

        //private byte[] StreamFile(string filename)
        //{
        //    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

        //    byte[] ImageData = System.IO.File.ReadAllBytes(filename);

        //    fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

        //    fs.Close();
        //    return ImageData; 
        //}
    }
}
