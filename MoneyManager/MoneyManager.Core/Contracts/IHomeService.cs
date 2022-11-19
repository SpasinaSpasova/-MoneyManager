using MoneyManager.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface IHomeService
    {
        Task<ViewModel> DashboardByUserId(string userId);
    }
}
