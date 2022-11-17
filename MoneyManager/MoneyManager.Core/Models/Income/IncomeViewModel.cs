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
        public string ApplicationUserId { get; set; } = null!;
    }
}
