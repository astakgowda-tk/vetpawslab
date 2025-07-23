using Aspire.Vetpaws.Lab.Data.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspire.Vetpaws.Lab.Controllers
{
    [Authorize(Roles = "Admin,Moderator,SuperAdmin")]
    public class BillingController : Controller
    {
        private readonly IItemPriceData _itemPrice;
        private readonly ILogger<BillingController> _logger;

        public BillingController(
            IItemPriceData itemPrice,
            ILogger<BillingController> logger
            )
        {
            _itemPrice = itemPrice;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.PriceList = _itemPrice.GetPrice();
            ViewBag.Gender = new String[] { "FEMALE","MALE"};

            return View();
        }
    }
}
