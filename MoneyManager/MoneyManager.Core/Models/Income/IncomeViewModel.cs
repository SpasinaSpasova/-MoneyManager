using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models.Income
{
    public class IncomeViewModel
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public byte[]? Photo { get; set; }

        public string Category { get; set; } = null!;

        public string Account { get; set; } = null!;
        public string AccountUserId { get; set; } = null!;
    }
}
