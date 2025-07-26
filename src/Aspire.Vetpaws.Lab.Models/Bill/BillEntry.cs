using Aspire.Vetpaws.Lab.Models.Enum;

namespace Aspire.Vetpaws.Lab.Models.Bill
{
    public class BillEntry
    {
        public string PatientName { get; set; }
        public string OwnerName { get; set; }
        public int AgeInYear { get; set; }
        public int AgeInMonths { get; set; }
        public EGender Gender { get; set; }
        public string? ReferredBy { get; set; }
        public string RegistrationNumber { get; set; }
        public int DiscountApplied { get; set; } = 0;
        public bool DiscountFromDoctor { get; set; } = false;
        public DateTime BilledTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<BillEntryItem> Items { get; set; }
    }
}