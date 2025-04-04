using IncomeGoalTracker.Core.Models.Ceu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Interfaces
{
    public interface IClassCeuRepo
    {
        // Basic Operations
        Task<IEnumerable<ClassCeu>> GetAllClassCeusAsync();
        Task<ClassCeu> GetClassCeuByIdAsync(int id);
        Task<int> AddClassCeuAsync(ClassCeu classCeu);
        Task<bool> UpdateClassCeuAsync(ClassCeu classCeu);
        Task<bool> DeleteClassCeuAsync(int id);
        Task<bool> DeleteTrainingClassCeusAsync(int trainingClassId)

        // Additional Operations
        Task<IEnumerable<ClassCeu>> GetClassCeuForTrainingClassAsync(int trainingClassId);
        Task<IEnumerable<ClassCeu>> GetClassCeuForCertificateAsync(int certificateId);
    }
}
