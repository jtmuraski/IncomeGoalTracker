using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class ClassCeu
    {
        public int Id { get; set; }
        public int TrainingClassiD { get; set; }
        public int CertificateId { get; set; }
        public double CeuHours { get; set; }
    }
}
