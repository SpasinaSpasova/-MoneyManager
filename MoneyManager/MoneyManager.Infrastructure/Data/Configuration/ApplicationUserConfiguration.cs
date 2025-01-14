﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        //Uncomment the commented lines
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //builder.HasData(CreateApplicationUser());
        }

        //private List<ApplicationUser> CreateApplicationUser()
        //{
        //    var applicationUsers = new List<ApplicationUser>();
        //    var hasher = new PasswordHasher<ApplicationUser>();

        //    var firstApplicationUser = new ApplicationUser()
        //    {
        //        Id = "55098375-47e8-4589-816e-268d714f568b",
        //        FirstName = "Pesho",
        //        LastName = "Petrov",
        //        Email = "petrov@mail.com",
        //        NormalizedEmail= "PETROV@MAIL.COM",
        //        UserName = "pesho",
        //        NormalizedUserName="PESHO"
        //    };

        //    firstApplicationUser.PasswordHash = hasher.HashPassword(firstApplicationUser, "first123");

        //    applicationUsers.Add(firstApplicationUser);

        //    var secondApplicationUser = new ApplicationUser()
        //    {
        //        Id = "ce00c486-6a17-41da-804f-40a576cd020d",
        //        FirstName = "Ivan",
        //        LastName = "Ivanov",
        //        Email = "ivanov@mail.com",
        //        NormalizedEmail= "IVANOV@MAIL.COM",
        //        UserName = "vankata",
        //        NormalizedUserName="VANKATA"
        //    };

        //    secondApplicationUser.PasswordHash = hasher.HashPassword(secondApplicationUser, "second123");

        //    applicationUsers.Add(secondApplicationUser);


        //    var adminApplicationUser = new ApplicationUser()
        //    {
        //        Id = "06408ed5-1bfe-4e54-9269-b9dfce131f44",
        //        FirstName = "Admin",
        //        LastName = "Admin",
        //        Email = "admin@mail.com",
        //        NormalizedEmail = "ADMIN@MAIL.COM",
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN"
        //    };

        //    adminApplicationUser.PasswordHash = hasher.HashPassword(adminApplicationUser, "admin123");

        //    applicationUsers.Add(adminApplicationUser);

        //    return applicationUsers;
        //}
    }
}
