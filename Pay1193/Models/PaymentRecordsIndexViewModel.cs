using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pay1193.Models
{
    public class PaymentRecordsIndexViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Employee { get; set; }
        public DateTime PayDate { get; set; }
        public string Month { get; set; }
        public string TaxYear { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public decimal NetPayment { get; set; }
        public string Actions { get; set; }
    }
}
