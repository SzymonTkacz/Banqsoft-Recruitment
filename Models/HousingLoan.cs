using System;
using System.ComponentModel.DataAnnotations;

namespace Banqsoft.Models
{
    public class HousingLoan
    {
        public double Rate = 3.5;

        [Required]
        [Range(10000, 300000)]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [Range(5, 40)]
        public int PaybackTime { get; set; }
        public double MonthlyPayback { get; set; }
        public double MonthlyInterest { get; set; }
        public double MonthlyTotal { get; set; }
        public double TotalCost { get; set; }
    }
}
