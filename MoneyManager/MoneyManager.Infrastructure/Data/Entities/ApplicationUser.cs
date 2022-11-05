using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoneyManager.Infrastructure.Data.DataConstants.ApplicationUser;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; init; } = null!;

        public List<Income> Incomes { get; set; } = new List<Income>();

        public List<Expense> Expenses { get; set; } = new List<Expense>();
        
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
