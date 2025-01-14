﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.Data.Configuration;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryExpenseConfiguration());
            builder.ApplyConfiguration(new CategoryIncomeConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new IncomeConfiguration());
            builder.ApplyConfiguration(new ExpenseConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserAndRole());

            base.OnModelCreating(builder);
        }
        public DbSet<CategoryIncome> CategoryIncomes { get; set; } = null!;

        public DbSet<CategoryExpense> CategoryExpenses { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;

        public DbSet<Income> Incomes { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

    }
}