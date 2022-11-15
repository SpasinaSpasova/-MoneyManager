using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoneyManager.Infrastructure.Data.DataConstants.Account;

namespace MoneyManager.Core.Models.Account
{
    public class AddAccountViewModel
    {
        [Required]
        [StringLength(AccountNameMaxLength,MinimumLength =AccountNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        [Range(typeof(decimal), "0.1", "1000000000000", ConvertValueInInvariantCulture = true,ErrorMessage = "The amount must be greater than 1!")]
        public decimal Amount { get; set; }
    }
}
