using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoneyManager.Infrastructure.Data.Configuration;
using MoneyManager.Infrastructure.Data.Entities;
using System.Reflection.Emit;

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

            base.OnModelCreating(builder);
        }
        public DbSet<CategoryIncome> CategoryIncomes { get; set; } = null!;

        public DbSet<CategoryExpense> CategoryExpenses { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;

        public DbSet<Income> Incomes { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

    }
}