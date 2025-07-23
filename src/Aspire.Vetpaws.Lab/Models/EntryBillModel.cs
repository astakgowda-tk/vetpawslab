using Aspire.Vetpaws.Lab.Models.Enum;

namespace Aspire.Vetpaws.Lab.Models
{
    public class EntryBillModel
    {
        public string PatientName { get; set; }
        public string OwnerName { get; set; }
        public int AgeInYear { get; set; }
        public int AgeInMonths { get; set; }
        public EGender Gender { get; set; }
        public string ReferredBy { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime BilledTime { get; set; } = DateTime.Now;

        public List<BillItemModel> Items { get; set; }
    }
}