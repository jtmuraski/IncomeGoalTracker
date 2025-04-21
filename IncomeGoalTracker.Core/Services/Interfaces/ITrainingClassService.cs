using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Services.Interfaces
{
    public interface ITrainingClassService
    {
        Task<bool> AddTrainingClassAsync(TrainingClassView trainingClassView, IEnumerable<ClassCeuView> classCeus);
        Task<bool> DeleteTrainingClassAsync(int id);
        Task<IEnumerable<TrainingClassView>> GetAllTrainingClassesAsync();
        Task<bool> UpdateTrainingClassAsync(TrainingClassView trainingClass);
        Task<IEnumerable<TrainingClass>> GetTrainingClassesByCertificateIdAsync(int certificateId);
        Task<TrainingClassView> GetTrainingClassByIdAsync(int id);

    }
}
