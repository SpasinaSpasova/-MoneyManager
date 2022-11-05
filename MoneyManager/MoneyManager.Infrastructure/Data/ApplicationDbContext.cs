using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryIncome> CategoryIncomes { get; set; } = null!;

        public DbSet<CategoryExpense> CategoryExpenses { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;

        public DbSet<Income> Incomes { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

    }
}