using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class ClassCeuUi
    {
        // UI Class for ClassCeu
        public int Id { get; set; }
        [DisplayName("Certificate Name")]
        public int CertificateId { get; set; }
        [DisplayName("CEU Hours")]
        [Range(0.1, 100.00, ErrorMessage = "CEU hours must be between 0.1 and 100")]
        public double CeuHours { get; set; }
    }
}
