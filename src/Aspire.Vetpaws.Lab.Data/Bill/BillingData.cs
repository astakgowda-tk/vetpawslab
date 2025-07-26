using Aspire.Vetpaws.Lab.Models.Bill;
using System.Text.Json;

namespace Aspire.Vetpaws.Lab.Data.Bill
{
    public class BillingData : IBillingData
    {
        public bool AddBill(BillEntry bill)
        {
            using var reader = new StreamReader("data/Billing.json");
            string json = reader.ReadToEnd();
            var billDetails = JsonSerializer.Deserialize<List<BillEntry>>(json);
            reader.Close();

            if (billDetails == null)
            {
                billDetails = new List<BillEntry>();
            }
            billDetails.Add(bill);
            string updatedJson = JsonSerializer.Serialize(billDetails, new JsonSerializerOptions { WriteIndented = true });
            using var writer = new StreamWriter("data/Billing.json");
            writer.Write(updatedJson);
            writer.Flush();
            writer.Close();

            return true;
        }
    }
}
