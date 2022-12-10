using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    public class ApplicationUserAndRole : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        //Uncomment the commented lines
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
           // builder.HasData(CreateUserWithRole());
        }

        //private List<IdentityUserRole<string>> CreateUserWithRole()
        //{
        //    var userWithRoles = new List<IdentityUserRole<string>>();

        //    var firstUser= new IdentityUserRole<string>()
        //    {
        //        RoleId = "ff4d8b6c-2017-4adf-b3e0-3d297229ff50",
        //        UserId = "55098375-47e8-4589-816e-268d714f568b"
        //    };

        //    userWithRoles.Add(firstUser);

        //    var secondUser = new IdentityUserRole<string>()
        //    {
        //        RoleId = "ff4d8b6c-2017-4adf-b3e0-3d297229ff50",
        //        UserId = "ce00c486-6a17-41da-804f-40a576cd020d"
        //    };

        //    userWithRoles.Add(secondUser);

        //    var adminUser = new IdentityUserRole<string>()
        //    {
        //        RoleId = "dca26d61-afe6-44ba-b9fc-f4b912b8acd0",
        //        UserId = "06408ed5-1bfe-4e54-9269-b9dfce131f44"
        //    };

        //    userWithRoles.Add(adminUser);

        //    return userWithRoles;
        //}
    }
}
