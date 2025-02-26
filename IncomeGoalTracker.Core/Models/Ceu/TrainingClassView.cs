using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class TrainingClassView
    { 
        public int Id { get; set; }

        [Required]
        [DisplayName("Course Name")]
        [StringLength(150, ErrorMessage ="Must be shorter than 150 characters")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Name of Training Provider")]
        [StringLength(150, ErrorMessage = "Must be less than 150 characters")]
        public string Provider { get; set; }

        [Required]
        [DisplayName("CEU's Earned")]
        [Range(0,100, ErrorMessage = "Must be between 0 and 100")]
        public double CeusEarned { get; set; }

        [Required]
        [DisplayName("Date Training Completed")]
        public DateOnly DateComplete { get; set; }


        public string CertificateLocation { get; set; }

        //NOTE: The CEU's for a class can be assigned to multiple certificates. The full CEU amount can also be assigned to more than one certificate.
        // FOr example, a class that is 2 CEU's can be assigned to 2 certificates. The full 2 CEU's can be assigned to each certificate, or 1 to each.
        // It will vary on a case by case basis
        public List<ClassCeu> ClassCeus { get; set; } = new List<ClassCeu>();
    }
}
