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
