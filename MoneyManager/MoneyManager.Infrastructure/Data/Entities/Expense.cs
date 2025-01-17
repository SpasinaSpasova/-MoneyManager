﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public byte[]? Photo { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public CategoryExpense Category { get; set; } = null!;

        [Required]
        public Guid AccountId { get; set; }

        [Required]
        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;

        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
