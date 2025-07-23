using Microsoft.AspNetCore.Mvc;

namespace Aspire.Vetpaws.Lab.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
