using Aspire.Vetpaws.Lab.Data.Bill;
using Aspire.Vetpaws.Lab.Models.Bill;

namespace Aspire.Vetpaws.Lab.Service.Billing
{
    public class BillingService : IBillingService
    {
        private readonly IBillingData _billingData;
        private readonly IItemPriceData _itemPrice;

        public BillingService(
            IBillingData billingData
            , IItemPriceData itemPrice)
        {
            _billingData = billingData;
            _itemPrice = itemPrice;
        }

        public void AddBill(BillEntry bill)
        {
            if (bill == null)
            {
                throw new ArgumentNullException(nameof(bill), "Bill entry cannot be null");
            }

            if (bill.Items?.Sum(x => x.TotalPrice) <= 0)
            {
                throw new ArgumentOutOfRangeException("Bill amount must be greater than zero");
            }
            _billingData.AddBill(bill);
        }

        public IEnumerable<ItemPrice> GetItemPrices()
        {
            var itemPrices = _itemPrice.GetItemPrices();
            if (itemPrices == null || !itemPrices.Any())
            {
                throw new InvalidOperationException("No item prices found");
            }
            return itemPrices;
        }
    }
}