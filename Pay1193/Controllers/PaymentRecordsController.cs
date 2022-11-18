using Microsoft.AspNetCore.Mvc;
using Pay1193.Services;
using Pay1193.Entity;
using Pay1193.Models;
using Pay1193.Services.Implement;
using Microsoft.AspNetCore.Hosting;

namespace Pay1193.Controllers
{
    public class PaymentRecordsController : Controller
    {
        private readonly IPayService _payService;
        private readonly IEmployee _employeeSerive;

        public PaymentRecordsController(IPayService payService, IEmployee employeeSerive)
        {
            _payService = payService;
            _employeeSerive = employeeSerive;
        }

        public IActionResult Index()
        {
            var record = _payService.GetAll().Select(record => new PaymentRecordsIndexViewModel
            {
                Employee = "Hector",//record.Employee.FirstName,
                PayDate = record.PayDate,
                Month = record.PayMonth.ToString(),
                TaxYear = "2021/2022",//record.TaxYear.ToString(),
                TotalEarnings = record.TotalEarnings.ToString(),
                TotalDeductions = record.TotalDeduction.ToString(),
                NetPayment = record.NetPayment

            }).ToList();
            return View(record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PaymentRecordsCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentRecordsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var record = new PaymentRecord
                {
                    Id = model.Id,//model.Id,
                    PayDate = model.PayDate,
                    PayMonth = model.PayMonth,
                    TaxYearId = model.TaxYearId,
                    HourlyRate = model.HourlyRate,
                    HoursWorked = model.HoursWorked,
                    ContractualHours = model.ContractualHours,
                    
                    TaxCode = model.Tax.ToString(),
                    fullName = model.FullName,
                    NiNo = model.NiNo,
                    OvertimeHours = model.OverTimeHours,
                    ContractualEarnings = 123,
                    OvertimeEarnings = 456,
                    Tax = 100,
                    NiC = model.NIC,
                    SLC = model.SLC,
                    TotalEarnings = model.TotalEarnings,
                    TotalDeduction = model.TotalDedution,
                    NetPayment = model.NetPayment
                };
                

                await _payService.CreateAsync(record);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
