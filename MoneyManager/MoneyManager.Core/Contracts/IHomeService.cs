using MoneyManager.Core.Models.Home;

namespace MoneyManager.Core.Contracts
{
    public interface IHomeService
    {
        Task<ViewModel> DashboardByUserId(string userId);
    }
}
