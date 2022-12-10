using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //Uncomment the commented lines
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // builder.HasData(CreateRoles());
        }

        //private List<IdentityRole> CreateRoles()
        //{
        //    var roles = new List<IdentityRole>();

        //    var userRole=new IdentityRole{
        //        Id = "ff4d8b6c-2017-4adf-b3e0-3d297229ff50",
        //        Name = "User",
        //        NormalizedName = "USER",
        //        ConcurrencyStamp = "23cf9348-0c8e-4b74-9c27-0de02fe00463"
        //    };

        //    roles.Add(userRole);

        //    var adminRole = new IdentityRole
        //    {
        //        Id = "dca26d61-afe6-44ba-b9fc-f4b912b8acd0",
        //        Name = "Admin",
        //        NormalizedName = "ADMIN",
        //        ConcurrencyStamp = "f036bdaf-9396-4bee-be22-ffe49bbb648a"
        //    };

        //    roles.Add(adminRole);

        //    return roles;
        //}
    }
}
