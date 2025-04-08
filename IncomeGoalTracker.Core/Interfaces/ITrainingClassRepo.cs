using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Interfaces
{
    public interface ITrainingClassRepo
    {
        // Basic Operations
        Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync();
        Task<TrainingClass> GetTrainingClassByIdAsync(int id);
        Task<int> AddTrainingClassAsync(TrainingClass trainingClass);
        Task<bool> DeleteTrainingClassAsync(int id);
        Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass);

    }
}
