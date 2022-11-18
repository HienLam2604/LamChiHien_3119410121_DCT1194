using Pay1193.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pay1193.Models
{
    public class PaymentRecordsCreateViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string FullName { get; set; } 
        public string NiNo { get; set; }

        public string PayMonth { get; set; }

        public int TaxYearId { get; set; }

        [DataType(DataType.Date), Display(Name = "Pay date")]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Employee Number is required")]
        public decimal HourlyRate { get; set; }

        public decimal HoursWorked { get; set; }
        public decimal ContractualHours { get; set; }

        public decimal OverTimeHours { get; set; }

        public decimal Tax { get; set; }
        public decimal NIC { get; set; }
        public decimal UnionFee { get; set; }
        public decimal SLC { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDedution { get; set; }
        public decimal NetPayment { get; set; }





    }
}
