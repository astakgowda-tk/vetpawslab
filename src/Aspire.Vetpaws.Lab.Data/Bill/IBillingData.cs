using Aspire.Vetpaws.Lab.Models.Bill;

namespace Aspire.Vetpaws.Lab.Data.Bill
{
    public interface IBillingData
    {
        public bool AddBill(BillEntry bill);
    }
}
