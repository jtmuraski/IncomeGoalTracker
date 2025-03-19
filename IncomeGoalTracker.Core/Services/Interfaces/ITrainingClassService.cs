using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Services.Interfaces
{
    internal interface ITrainingClassService
    {
        Task<bool> AddTrainingClassAsync(TrainingClass trainingClass);
        Task<bool> DeleteTrainingClassAsync(int id);
        Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync();
        Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass);
    }
}
