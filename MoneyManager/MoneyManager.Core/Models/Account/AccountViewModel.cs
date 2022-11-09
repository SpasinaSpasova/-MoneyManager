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
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Amount { get; set; }

        public string ApplicationUserId { get; set; } = null!;
    }
}
