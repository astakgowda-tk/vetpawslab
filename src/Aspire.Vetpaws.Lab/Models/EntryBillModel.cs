using Aspire.Vetpaws.Lab.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aspire.Vetpaws.Lab.Models
{
    public class EntryBillModel
    {
        [Required]
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }
        [Required]
        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }
        [Required]
        [DisplayName("Years")]
        public int AgeInYear { get; set; }
        [Required]
        [DisplayName("Months")]
        public int AgeInMonths { get; set; }
        [Required]
        public EGender Gender { get; set; }
        public string? ReferredBy { get; set; }
        [DisplayName("Reg number")]
        public string RegistrationNumber { get; set; } = "20259341";
        [DisplayName("Discount")]
        public int DiscountApplied { get; set; } = 0;
        [DisplayName("Discount from Doctor")]
        public bool DiscountFromDoctor { get; set; } = false;

        public DateTime BilledTime { get; set; } = DateTime.Now;

        [BindProperty]
        public List<BillItemModel> Items { get; set; }
    }
}