using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models.Home
{
    public class TotalViewModel
    {
        public decimal IncomeTotal { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal Balance { get; set; }
    }
}
