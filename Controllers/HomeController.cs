using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banqsoft.Models;

namespace Banqsoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Loan(HousingLoan housingLoan)
        {
            housingLoan.TotalCost = Math.Round(housingLoan.Amount * Math.Pow(1 +((housingLoan.Rate / 100)), housingLoan.PaybackTime), 2);
            housingLoan.MonthlyTotal = Math.Round(housingLoan.TotalCost / (housingLoan.PaybackTime * 12), 2);
            housingLoan.MonthlyPayback = Math.Round(housingLoan.Amount / (housingLoan.PaybackTime * 12), 2);
            housingLoan.MonthlyInterest = Math.Round(housingLoan.MonthlyTotal - housingLoan.MonthlyPayback, 2);
            return View(housingLoan);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
