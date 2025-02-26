using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Models.Mappers
{
    public static class TrainingClassMapper
    {
        public static TrainingClass MapToView(TrainingClass trainingClass)
        {
            return new TrainingClassView()
            {
                Id = trainingClass.Id,
                Name = trainingClass.Name,
                Provider = trainingClass.Provider,
                CeusEarned = trainingClass.CeusEarned,
                DateComplete = trainingClass.DateComplete,
                CertificateLocation = trainingClass.CertificateLocation,
                ClassCeus = trainingClass.ClassCeus.Select(c => ClassCeuMapper.MapToView(c)).ToList()
            };
        }

        public static TrainingClassView MapToModel(TrainingClassView trainingClass)
        {
            return new TrainingClassView()
            {
                Id = trainingClass.Id,
                Name = trainingClass.Name,
                Provider = trainingClass.Provider,
                CeusEarned = trainingClass.CeusEarned,
                DateComplete = trainingClass.DateComplete,
                CertificateLocation = trainingClass.CertificateLocation,
                ClassCeus = trainingClass.ClassCeus.Select(c => ClassCeuMapper.MapToView(c)).ToList()
            };
        }
    }
}
