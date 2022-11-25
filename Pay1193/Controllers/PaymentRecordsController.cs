using Microsoft.AspNetCore.Mvc;
using Pay1193.Services;
using Pay1193.Entity;
using Pay1193.Models;
using Pay1193.Services.Implement;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace Pay1193.Controllers
{
    public class PaymentRecordsController : Controller
    {
        private readonly IPayService _payService;
        private readonly IEmployee _employeeService;
        private readonly ITaxService _taxService;
        private readonly INationalInsuranceService _nationalInsuranceService;

        private int employeeId;
        private decimal tax;
        private decimal overTimeHrs;
        private decimal unionFee;
        private decimal studentLoan;
        private decimal nic;
        private decimal totalDecuction;
        private decimal totalEarnings;
        private decimal contractualEarnings;
        private decimal overtimeEarnings;

        private int taxYearId;

        public PaymentRecordsController(IPayService payService, IEmployee employeeSerive, ITaxService taxService, INationalInsuranceService nationalInsuranceService)
        {
            _payService = payService;
            _employeeService = employeeSerive;
            _taxService = taxService;
            _nationalInsuranceService = nationalInsuranceService;
        }

        public IActionResult Index()
        {
            var record = _payService.GetAll().Select(record => new PaymentRecordsIndexViewModel
            {
                Id = record.Id,
                FullName = record.FullName,
                PayDate = record.PayDate,
                PayMonth = record.PayMonth.ToString(),
                TaxYear = _payService.GetTaxYearById(record.TaxYearId).YearOfTax,
                TotalEarnings = record.TotalEarnings.ToString(),
                TotalDeductions = record.TotalDeduction.ToString(),
                NetPayment = record.NetPayment.ToString(),

            }).ToList();
            return View(record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PaymentRecordsCreateViewModel();

            var employee = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                FullName = employee.FirstName + " " + employee.MidleName + " " + employee.LastName,
            }).ToList();

            var taxYear = _taxService.GetAll().Select(tax => new TaxYearModel
            {
                Id = tax.Id,
                YearOfTax = tax.YearOfTax,
            }).ToList();

            ViewBag.Count = employee.Count();
            ViewBag.ListEmployee = employee; // list of employee
            
            ViewBag.TaxYear = taxYear; // list year of tax

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentRecordsCreateViewModel model)
        {


            var record = new PaymentRecords
            {
                Id = model.Id,
                EmployeeId = employeeId = _employeeService.GetById(1).Id,
                FullName = model.FullName,
                PayDate = model.PayDate,
                PayMonth = model.PayMonth,
                TaxYearId = model.TaxYearId,
                HourlyRate = model.HourlyRate,
                HoursWorked = model.HoursWorked,
                ContractualHours = model.ContractualHours,

                TaxCode = model.Tax.ToString(),
                NiNo = _employeeService.GetById(employeeId).NationalInsuranceNo,
                OvertimeHours = _payService.OverTimeHours(model.HoursWorked, model.ContractualHours),
                ContractualEarnings = contractualEarnings = _payService.ContractualEarning(model.ContractualHours, model.HoursWorked, model.HourlyRate),
                OvertimeEarnings = overtimeEarnings = _payService.OvertimeEarnings(model.OverTimeHours, model.HoursWorked),
                UnionFee = unionFee = _employeeService.UnionFee(employeeId),
                TotalEarnings = totalEarnings = _payService.TotalEarnings(overtimeEarnings,contractualEarnings),
                Tax = tax = _taxService.TaxAmount(totalEarnings),
                NIC = nic = _nationalInsuranceService.NIContribution(totalEarnings),
                SLC = studentLoan = _employeeService.StudentLoanRepaymentAmount(employeeId, totalEarnings),
                TotalDeduction = totalDecuction = _payService.TotalDeduction(tax, nic, studentLoan, unionFee),
                NetPayment = _payService.NetPay(totalEarnings, totalDecuction),
            };

                await _payService.CreateAsync(record);
                return RedirectToAction("Index");
          
        }



        public IActionResult Detail(int id)
        {
            var paySlip = _payService.GetById(id);
            if (paySlip == null)
            {
                return NotFound();
            }
            PaymentRecordDetailsViewModel model = new PaymentRecordDetailsViewModel()
            {
                Id = paySlip.Id,
                PayDate = paySlip.PayDate,
                TaxCode = paySlip.TaxCode,
                TaxYear = paySlip.TaxYear,
                Employee = paySlip.Employee,
                FullName = paySlip.FullName,
                NiNo = paySlip.NiNo,
                PayMonth = paySlip.PayMonth,
                TaxYearId = taxYearId =  paySlip.TaxYearId,
                Year = _taxService.GetById(taxYearId).YearOfTax,
                HourlyRate = paySlip.HourlyRate,
                HourlyWorked  = paySlip.HoursWorked,
                ContractualHours = paySlip.ContractualHours,
                OvertimeHours = paySlip.OvertimeHours,
                OvertimeRate = 123,
                ContractualEarnings = paySlip.ContractualEarnings,
                OvertimeEarnings = paySlip.OvertimeEarnings,
                Tax = paySlip.Tax,
                NIC = paySlip.NIC,
                UnionFee = paySlip.UnionFee,
                SLC = paySlip.SLC,
                TotalEarnings = paySlip.TotalEarnings,
                TotalDeduction = paySlip.TotalDeduction,
                NetPayment = paySlip.NetPayment

            };
            return View(model);
        }

    }
}
