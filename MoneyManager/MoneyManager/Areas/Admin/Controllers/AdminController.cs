using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
