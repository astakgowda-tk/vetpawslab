using Aspire.Vetpaws.Lab.Models;
using Aspire.Vetpaws.Lab.Models.Bill;
using Aspire.Vetpaws.Lab.Service.Billing;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aspire.Vetpaws.Lab.Controllers
{
    [Authorize(Roles = "Admin,Moderator,SuperAdmin")]
    public class BillingController : Controller
    {
        private readonly IBillingService _billingService;
        private readonly IMapper _mapper;
        private readonly ILogger<BillingController> _logger;

        public BillingController(
            IBillingService billingService,
            IMapper mapper,
            ILogger<BillingController> logger)
        {
            _billingService = billingService;
            _mapper = mapper;
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
                model.Items = model.Items.Where(x => x.Price > 0).ToList();
                var entryBill = _mapper.Map<BillEntry>(model);
                _billingService.AddBill(entryBill);
                return Redirect("/Billing/Index");
            }
            else
            {
                return View(model);
            }
        }

        private void SetViewBagData()
        {
            var itemPriceList = new List<ItemPrice>() { new ItemPrice { ItemName = "None", Price = 0 } };
            itemPriceList.AddRange(_billingService.GetItemPrices());

            ViewBag.PriceList = itemPriceList;
            ViewBag.Gender = new String[] { "FEMALE", "MALE" };
        }
    }
}
