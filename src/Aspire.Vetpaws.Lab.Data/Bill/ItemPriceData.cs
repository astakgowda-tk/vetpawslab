using Aspire.Vetpaws.Lab.Models.Bill;
using System.Text.Json;

namespace Aspire.Vetpaws.Lab.Data.Bill
{
    public class ItemPriceData : IItemPriceData
    {
        public IEnumerable<ItemPrice> GetItemPrices()
        {
            using var reader = new StreamReader("data/ItemPrice.json");
            string json = reader.ReadToEnd();
            var details = JsonSerializer.Deserialize<List<OrganizationItemPrice>>(json);
            reader.Close();

            return details?.FirstOrDefault(x => x.Organization == "Vetpaws")?.PriceList;
        }
    }
}
