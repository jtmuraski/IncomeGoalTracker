using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class Certificate
    {
        // ---Properties---
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public double CeusRequired { get; set; }
        public DateOnly CeuDueDate { get; set; }
        public int CertificateTrainingMonths { get; set; }
        public bool InProcess { get; set; }
        //JM 20Feb2025:
        //Note: This list is to include any training class that has any ceu hours > 0 assigned to it. If a training class provided by the user does NOT have a CEU hour > 0 
        // with this Certicates Id, it will not be included in this list. Because a TrainingClass can have hours assigned to more than one certificate, the TrainingClass object
        // Does not have a CertificateId Property. Instead, the ClassCeu object has a CertificateId property.
        public List<TrainingClass> TrainingClasses { get; set; } = new List<TrainingClass>();
        public double CeusEarned 
        {
            get
            {
                return TrainingClasses.SelectMany(c => c.ClassCeus).Where(ceu => ceu.CertificateId == this.Id).Sum(hours => hours.CeuHours);
            }
        }

        public double CeusRemaining
        {
            get
            {
                return this.CeusRequired - this.CeusEarned;
            }
        }

        // ---Constructors---
        public Certificate(string name, double ceus, DateOnly dueDate, int months, bool inProcess)
        {
            Name = name;
            CeusRequired = ceus;
            CeuDueDate = dueDate;
            CertificateTrainingMonths = months;
            InProcess = inProcess;
        }

    }
}
