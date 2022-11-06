using MoneyManager.Core.Models.Income;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Contracts
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeViewModel>> GetAllAsync();
    }
}
