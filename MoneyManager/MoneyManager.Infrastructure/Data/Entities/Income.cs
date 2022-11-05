using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class Income
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public byte[]? Photo { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public CategoryIncome Category { get; set; } = null!;

        [Required]
        public Guid AccountId { get; set; }

        [Required]
        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;
    }
}
