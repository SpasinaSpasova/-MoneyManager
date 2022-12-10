using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    public class AccountConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //builder.HasData(CreateAccounts());
        }

        //private List<Account> CreateAccounts()
        //{
        //    var accounts = new List<Account>();

        //    var firstAccount = new Account()
        //    {
        //        Id = new Guid("8c6feda1-c95c-4ba5-94a5-8402a483541b"),
        //        Name = "Wallet",
        //        Amount = 420.3m,
        //        ApplicationUserId= "55098375-47e8-4589-816e-268d714f568b"
        //    };

        //    accounts.Add(firstAccount);

        //    var secondAccount = new Account()
        //    {
        //        Id = new Guid("600450f8-17e8-498a-bd99-0ad81c8b3085"),
        //        Name = "Debit card",
        //        Amount = 1420m,
        //        ApplicationUserId= "ce00c486-6a17-41da-804f-40a576cd020d"
        //    };

        //    accounts.Add(secondAccount);

        //    var thirdAccount = new Account()
        //    {
        //        Id = new Guid("d0345a9a-b761-4522-88a8-560cbe3b1c52"),
        //        Name = "Piggy Bank",
        //        Amount = 330.56m,
        //        ApplicationUserId = "ce00c486-6a17-41da-804f-40a576cd020d"
        //    };

        //    accounts.Add(thirdAccount);

        //    return accounts;
        //}
    }
}
