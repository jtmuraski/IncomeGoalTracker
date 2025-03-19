using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models;
using IncomeGoalTracker.Core.Models.Ceu;

namespace IncomeGoalTracker.Core.Services.Interfaces
{
    internal interface IClassCeuService
    {
        Task<bool> AddClassCeuAsync(ClassCeu classCeu);
        Task<bool> DeleteClassCeuAsync(int id);
        Task<IEnumerable<ClassCeu>> GetAllClassCeusAsync();
        Task<bool> UpdateClassCeuAsync(ClassCeu classCeu);
    }
}
