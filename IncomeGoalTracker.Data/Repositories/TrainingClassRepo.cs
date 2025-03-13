using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Data.Repositories
{
    public class TrainingClassRepo : ITrainingClassRepo
    {
        public Task<int> AddTrainingClassAsync(TrainingClass trainingClass)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTrainingClassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TrainingClass> GetTrainingClassByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass)
        {
            throw new NotImplementedException();
        }
    }
}
