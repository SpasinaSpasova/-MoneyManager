using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models.Expense
{
    public class EditExpenseViewModel : AddExpenseViewModel
    {
        public Guid Id { get; set; }
    }
}
