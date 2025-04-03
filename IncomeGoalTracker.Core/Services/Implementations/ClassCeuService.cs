using IncomeGoalTracker.Core.Models.Ceu;
using IncomeGoalTracker.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeGoalTracker.Core.Services.Implementations
{
    public class ClassCeuService : IClassCeuService
    {
        public Task<bool> AddClassCeuAsync(ClassCeu classCeu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClassCeuAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassCeu>> GetAllClassCeusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateClassCeuAsync(ClassCeu classCeu)
        {
            throw new NotImplementedException();
        }
    }
}
