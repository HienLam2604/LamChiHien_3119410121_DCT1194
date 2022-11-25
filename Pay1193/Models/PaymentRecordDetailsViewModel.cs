using Pay1193.Entity;
using System.ComponentModel.DataAnnotations;

namespace Pay1193.Models
{
    public class PaymentRecordDetailsViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public string FullName { get; set; }
        public string NiNo { get; set; }

        [DataType(DataType.Date), Display(Name = "Pay date")]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }

        public int TaxYearId { get; set; }
        public string Year { get; set; }

        public TaxYears TaxYear { get; set ;}
        public string TaxCode { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HourlyWorked { get; set; }
        public decimal ContractualHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeRate { get; set; }
        public decimal ContractualEarnings { get; set; }
        public decimal OvertimeEarnings { get; set; }
        public decimal Tax { get; set; }
        public decimal NIC { get; set; }
        public decimal? UnionFee { get; set; }
        public Nullable<decimal> SLC { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPayment { get; set; }



    }
}
