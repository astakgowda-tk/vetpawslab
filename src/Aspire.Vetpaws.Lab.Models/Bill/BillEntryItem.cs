namespace Aspire.Vetpaws.Lab.Models.Bill
{
    public class BillEntryItem
    {
        public string ItemName { get; set; }
        public string? CustomItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 1;
        public int TotalPrice => Price * Quantity;
    }
}