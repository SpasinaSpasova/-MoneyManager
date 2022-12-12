namespace MoneyManager.Core.Models.Home
{
    public class ExpensesCategoriesViewModel
    {
        public List<string> CategoriesName { get; set; } = new List<string>();
        public List<double> ExpensesByCategoriesName { get; set; } = new List<double>();
    }
}
