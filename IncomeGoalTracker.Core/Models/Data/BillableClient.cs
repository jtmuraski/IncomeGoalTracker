using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Data
{
    public class BillableClient
    {
        public int CalculationId { get; set; }
        public int ClientNumber { get; set; }
        public decimal TotalBillableAmount { get; set; }
        public decimal TotalPercentangeDeductions { get; set; }
        public decimal TotalTaxDeductions { get; set; }
        public decimal TotalExtraDeductions { get; set; }
        public decimal TotalNetIncome { get; set; }
    }
}
