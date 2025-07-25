using Aspire.Vetpaws.Lab.Data.Bill;
using Aspire.Vetpaws.Lab.Models;
using Aspire.Vetpaws.Lab.Models.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            SetViewBagData();
            var billModel = new EntryBillModel
            {
                Items = new List<BillItemModel>
                {
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel(),
                    new BillItemModel()
                }
            };

            return View(billModel);
        }

        [HttpPost]
        public IActionResult Index(EntryBillModel model)
        {
            SetViewBagData();
            if (ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        private void SetViewBagData()
        {
            var itemPriceList = new List<ItemPrice>() { new ItemPrice { ItemName = "None", Price = 0 } };
            itemPriceList.AddRange(_itemPrice.GetPrice());

            ViewBag.PriceList = itemPriceList;
            ViewBag.Gender = new String[] { "FEMALE", "MALE" };
        }
    }
}
