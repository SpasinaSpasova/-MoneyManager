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

            public const int ApplicationUserPasswordMaxLength = 10;
            public const int ApplicationUserPasswordMinLength = 4;

            public const int ApplicationUserUserNameMinLength = 5;
            public const int ApplicationUserUserNameMaxLength = 15;

            public const int ApplicationUserEmailMinLength = 12;
            public const int ApplicationUserEmailMaxLength = 35;
        }
    }
}
