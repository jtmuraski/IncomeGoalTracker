using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models.Validations;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class CertificateView
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Certificate Abbreviation")]
        [StringLength(12, ErrorMessage = "An abbreviation must be less than 12 characters")]
        public string Abbreviation { get; set; }

        [Required]
        [DisplayName("Required CEU's Per Cycle")]
        [Range(0, 100, ErrorMessage = "CEU's must be between 0 and 100")]
        public double CeusRequired { get; set; }

        [Required]
        [DisplayName("CEU Due Date")]
        [FutureDate]
        public DateOnly CeuDueDate { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Months must be between 1 and 100")]
        [DisplayName("Training Perior (In Months)")]
        public int CertificateTrainingMonths { get; set; }

        public bool InProcess { get; set; }

        public List<TrainingClass> TrainingClasses { get; set; } = new List<TrainingClass>();

        [DisplayFormat(DataFormatString = "{0:F1}")]
        [DisplayName("CEU's Earned")]
        public double CeusEarned { get; set; }

        [DisplayName("CEU's Remaining")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double CeusRemaining { get; set; }

    }
}
