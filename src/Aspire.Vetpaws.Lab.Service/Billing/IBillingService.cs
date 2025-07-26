using Aspire.Vetpaws.Lab.Models.Bill;

namespace Aspire.Vetpaws.Lab.Service.Billing
{
    public interface IBillingService
    {
        void AddBill(BillEntry bill);
        IEnumerable<ItemPrice> GetItemPrices();
    }
}
