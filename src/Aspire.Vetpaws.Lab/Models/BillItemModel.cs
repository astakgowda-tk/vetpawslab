namespace Aspire.Vetpaws.Lab.Models
{
    public class BillItemModel
    {
        public int SerialNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDiscount { get; set; }
        public decimal DiscountApplied { get; set; }
        public string Remarks { get; set; }
        public BillItemModel(int serialNumber, string itemName, string itemDescription, decimal price, int quantity, string remarks)
        {
            SerialNumber = serialNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            Price = price;
            Quantity = quantity;
            Remarks = remarks;
        }
    }
}