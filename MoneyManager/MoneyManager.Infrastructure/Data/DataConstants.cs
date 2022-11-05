using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Data
{
    public static class DataConstants
    {
        public class CategoryExpensesAndIncomes
        {
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 20;
        }
        public class Account
        {
            public const int AccountNameMinLength = 2;
            public const int AccountNameMaxLength = 20;
        }
        public class ApplicationUser
        {
            public const int ApplicationUserFirstNameMinLength = 2;
            public const int ApplicationUserFirstNameMaxLength = 25;

            public const int ApplicationUserLastNameMinLength = 2;
            public const int ApplicationUserLastNameMaxLength = 25;
        }
    }
}
