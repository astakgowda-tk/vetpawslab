using Aspire.Vetpaws.Lab.Models.Bill;

namespace Aspire.Vetpaws.Lab.Data.Bill
{
    public interface IItemPriceData
    {
        IEnumerable<ItemPrice> GetPrice();
    }
}
