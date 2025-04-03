using IncomeGoalTracker.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeGoalTracker.Core.Models.Ceu;
using Microsoft.Extensions.Logging;
using IncomeGoalTracker.Core.Interfaces;
using IncomeGoalTracker.Core.Models.Mappers;

namespace IncomeGoalTracker.Core.Services.Implementations
{
    public class TrainingClassService : ITrainingClassService
    {
        private readonly ITrainingClassRepo _trainingClassRepo;
        private readonly ILogger<TrainingClassService> _logger;
        public TrainingClassService(ITrainingClassRepo trainingClassRepo, ILogger<TrainingClassService> logger)
        {
            _trainingClassRepo = trainingClassRepo;
            _logger = logger;
        }
        public async Task<bool> AddTrainingClassAsync(TrainingClassView trainingClassView, IEnumerable<ClassCeuView> classCeuViews)
        {
            _logger.LogInformation("Adding new training class");
            TrainingClass trainingClass = TrainingClassMapper.MapToModel(trainingClassView);
            int id = await _trainingClassRepo.AddTrainingClassAsync(trainingClass);
            if (id > 0)
            {
                _logger.LogInformation($"Training class added with ID: {id}");
                return true;
            }
            else
            {
                _logger.LogError("Failed to add training class");
                return false;
            }
        }

        public async Task<bool> DeleteTrainingClassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass)
        {
            throw new NotImplementedException();
        }
    }
}
