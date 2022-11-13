using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models.Account;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models.Expense
{
    public class AddExpenseViewModel
    {
        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        [Range(typeof(decimal), "0.1", "1000000000000", ConvertValueInInvariantCulture = true)]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public List<CategoryExpense> Categories { get; set; } = new List<CategoryExpense>();

        [Required]
        public Guid AccountId { get; set; }

        public List<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>();
    }
}
