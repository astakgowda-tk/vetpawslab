using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aspire.Vetpaws.Lab.Models
{
    public class BillItemModel
    {
        [Required]
        [DisplayName("Item")]
        public string ItemName { get; set; }
        [DisplayName("Custom Item Name")]
        public string? CustomItemName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
        public int TotalPrice => Price * Quantity;
    }
}