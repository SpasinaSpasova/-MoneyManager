﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MoneyManager.Infrastructure.Data.DataConstants.Account;

namespace MoneyManager.Infrastructure.Data.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(AccountNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
