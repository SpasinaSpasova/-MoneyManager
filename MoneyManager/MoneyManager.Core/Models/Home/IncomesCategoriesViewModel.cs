namespace MoneyManager.Core.Models.Home
{
    public class IncomesCategoriesViewModel
    {
        public List<string> CategoriesName { get; set; } = new List<string>();
        public List<double> IncomesByCategoriesName { get; set; } = new List<double>();
    }
}
