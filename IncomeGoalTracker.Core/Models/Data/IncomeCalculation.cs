using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Data
{
    public class IncomeCalculation
    {
        // ---Properties---
        public int Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public decimal IncomeGoal { get; set; }
        public decimal SavingsGoal { get; set; }
        public decimal SharePercentage { get; set; }
        public decimal Taxpercentage { get; set; } 
        public decimal AverageBillablePerClient { get; set; }
        public decimal ExtraDeductions { get; set; }
        public int MaxClients { get; set; }
        public List<BillableClient>? BillableClients { get; set; }

        // ---Constructors---
        public IncomeCalculation()
        {
            BillableClients = new List<BillableClient>();
        }
        // ---Methods---
    }
}
