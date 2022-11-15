using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MoneyManager.Infrastructure.Data.Entities;
using MoneyManager.Core.Models.Account;

namespace MoneyManager.Core.Models.Income
{
    public class AddIncomeViewModel
    {
        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        [Range(typeof(decimal), "0.1", "1000000000000", ConvertValueInInvariantCulture = true, ErrorMessage = "The amount must be greater than 1!")]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public List<CategoryIncome> Categories { get; set; } = new List<CategoryIncome>();

        [Required]
        public Guid AccountId { get; set; }

        public List<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>();


    }
}
