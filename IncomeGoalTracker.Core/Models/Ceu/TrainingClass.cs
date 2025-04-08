using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Ceu
{
    public class TrainingClass
    { 
        // ---Properties---
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public double CeusEarned { get; set; }
        public DateOnly DateComplete { get; set; }
        public string CertificateLocation { get; set; }
        //NOTE: The CEU's for a class can be assigned to multiple certificates. The full CEU amount can also be assigned to more than one certificate.
        // FOr example, a class that is 2 CEU's can be assigned to 2 certificates. The full 2 CEU's can be assigned to each certificate, or 1 to each.
        // It will vary on a case by case basis
        public List<ClassCeu> ClassCeus { get; set; } = new List<ClassCeu>();

        // ---Constructors---
        public TrainingClass()
        {
            
        }
        public TrainingClass(string name, string provider, double ceus, DateOnly dateComplete)
        {
            Name = name;
            Provider = provider;
            CeusEarned = ceus;
            DateComplete = dateComplete;
            CertificateLocation = string.Empty;
        }


        // ---Class and Instance Methods---
        /// <summary>
        /// Add a new CEU record for this instance
        /// </summary>
        /// <param name="CertificateId"></param>
        /// <param name="CeuHours"></param>
        public void AddClassCeu(int CertificateId, double CeuHours)
        {
            ClassCeus.Add(new ClassCeu { CertificateId = CertificateId, CeuHours = CeuHours });
        }

        /// <summary>
        /// Remove a CEU record from this instance
        /// </summary>
        /// <param name="CertificateId"></param>
        public void RemoveClassCeu(int CertificateId)
        {
            ClassCeus.RemoveAll(ceu => ceu.CertificateId == CertificateId);
        }
    }
}
