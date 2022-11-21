using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models.Home
{
    public class ViewModel
    {
        public TotalViewModel Totals { get; set; }
        public IncomesCategoriesViewModel IncomesCategories { get; set; }
        public ExpensesCategoriesViewModel ExpensesCategories { get; set; }
        public IncomesAndExpensesForWeek IncomesAndExpensesForWeek { get; set; }
    }
}
