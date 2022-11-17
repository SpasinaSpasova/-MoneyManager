using MoneyManager.Core.Models.Account;

namespace MoneyManager.Core.Contracts
{
    public interface IAccountService
    {
        Task<List<AccountViewModel>> GetAllByUserIdAsync(string userId);
        Task AddAccountAsync(AddAccountViewModel model, string userId);
        Task<EditAccountViewModel> GetForEditAsync(Guid id);
        Task EditAsync(EditAccountViewModel model);
        Task DeleteAsync(Guid id);
    }
}
