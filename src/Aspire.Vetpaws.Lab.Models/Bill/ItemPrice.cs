namespace Aspire.Vetpaws.Lab.Models.Bill
{
    public class OrganizationItemPrice
    {
        public string Organization { get; set; }
        public ItemPrice[] PriceList { get; set; }
    }

    public class ItemPrice
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Price { get; set; }
    }

}
