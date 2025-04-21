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
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace IncomeGoalTracker.Core.Services.Implementations
{
    public class TrainingClassService : ITrainingClassService
    {
        private readonly ITrainingClassRepo _trainingClassRepo;
        private readonly IClassCeuRepo _classCeuRepo;
        private readonly ILogger<TrainingClassService> _logger;
        public TrainingClassService(ITrainingClassRepo trainingClassRepo, IClassCeuRepo classCeuRepo, ILogger<TrainingClassService> logger)
        {
            _trainingClassRepo = trainingClassRepo;
            _classCeuRepo = classCeuRepo;
            _logger = logger;
        }
        public async Task<bool> AddTrainingClassAsync(TrainingClassView trainingClassView, IEnumerable<ClassCeuView> classCeuViews)
        {
            try
            {
                _logger.LogInformation("Adding new training class");
                TrainingClass trainingClass = TrainingClassMapper.MapToModel(trainingClassView);
                int id = await _trainingClassRepo.AddTrainingClassAsync(trainingClass);
                if (id > 0)
                {
                    _logger.LogInformation($"Training class added with ID: {id}");
                    _logger.LogInformation("Allocating CEU's to Certifications");
                    foreach (var classCeuView in classCeuViews)
                    {
                        _logger.LogInformation($"Adding CEU to Certificate Id {classCeuView.CertificateId} on training class {id}");
                        ClassCeu classCeu = ClassCeuMapper.MapToModel(classCeuView);
                        classCeu.TrainingClassiD = id;
                        int ceuId = await _classCeuRepo.AddClassCeuAsync(classCeu);
                        if (ceuId > 0)
                        {
                            _logger.LogInformation($"Class CEU added with ID: {ceuId}");
                        }
                        else
                        {
                            _logger.LogError($"Failed to add Class");
                        }
                    }
                    return true;
                }
                else
                {
                    _logger.LogError("Failed to add training class");
                    return false;
                }
            }
            catch(SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch(Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
        }

        public async Task<bool> DeleteTrainingClassAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting Training Class {id}");
                // Delete the Class CEU's first to avoid foreign key constraint violations
                bool classCeuComplete = await _classCeuRepo.DeleteTrainingClassCeusAsync(id);
                if (!classCeuComplete)
                {
                    _logger.LogError($"Failed to delete Class CEU's for Training Class {id}");
                    return false;
                }

                bool complete = await _trainingClassRepo.DeleteTrainingClassAsync(id);
                if(complete)
                {
                    bool ceuComplete = await _classCeuRepo.DeleteTrainingClassCeusAsync(id);
                }
                return true;
            }
            catch (SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
        }

        public async Task<IEnumerable<TrainingClassView>> GetAllTrainingClassesAsync()
        {
            try
            {
                _logger.LogInformation("Getting Training Classes");
                IEnumerable<TrainingClass> trainingClasses = await _trainingClassRepo.GetAllTrainingClassesAsync();
                List<TrainingClassView> trainingClassViews = new List<TrainingClassView>();

                if (trainingClasses.Any())
                {
                    _logger.LogInformation("Getting Class CEU's for training classes");
                    foreach(var trainingClass in trainingClasses)
                    {
                        IEnumerable<ClassCeu> classCeus = await _classCeuRepo.GetClassCeuForTrainingClassAsync(trainingClass.Id);
                        trainingClass.ClassCeus = classCeus.ToList();
                    }

                    foreach(var trainingClass in trainingClasses)
                    {
                        trainingClassViews.Add(TrainingClassMapper.MapToView(trainingClass));
                    }

                    return trainingClassViews;
                }
                else
                {
                    _logger.LogInformation("No training classes found");
                    return Enumerable.Empty<TrainingClassView>();
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
        }

        public async Task<IEnumerable<TrainingClass>> GetTrainingClassesByCertificateIdAsync(int certificateId)
        {
            try
            {
                _logger.LogInformation($"Getting Training Classes for Certification Id {certificateId}");
                IEnumerable<TrainingClass> trainingClasses = await _trainingClassRepo.GetTrainingClassesByCertificateIdAsync(certificateId);
                List<TrainingClassView> trainingClassViews = new List<TrainingClassView>();

                if (trainingClasses.Any())
                {
                    _logger.LogInformation("Getting Class CEU's for training classes");
                    foreach (var trainingClass in trainingClasses)
                    {
                        IEnumerable<ClassCeu> classCeus = await _classCeuRepo.GetClassCeuForTrainingClassAsync(trainingClass.Id);
                        trainingClass.ClassCeus = classCeus.ToList();

                    }

                    return trainingClasses;
                }
                else
                {
                    _logger.LogInformation($"No training classes found for Certificate Id {certificateId}");
                    return Enumerable.Empty<TrainingClass>();
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }

        }

        public async Task<bool> UpdateTrainingClassAsync(TrainingClassView trainingClass)
        {
            try
            {
                _logger.LogInformation($"Updating Training Class {trainingClass.Id}");
                var trainingClassModel = TrainingClassMapper.MapToModel(trainingClass);
                bool complete = await _trainingClassRepo.UpdateTrainingClassAsync(trainingClassModel);
                bool ceuComplete = false;

                if (complete)
                {
                    foreach(var classCeu in trainingClass.ClassCeus)
                    {
                        ClassCeu classCeuModel = ClassCeuMapper.MapToModel(classCeu);
                        classCeuModel.TrainingClassiD = trainingClass.Id;
                        if(classCeuModel.Id == 0)
                        {
                            classCeuModel.TrainingClassiD = trainingClass.Id;
                            int ceuId = await _classCeuRepo.AddClassCeuAsync(classCeuModel);
                            if (ceuId > 0)
                            {
                                _logger.LogInformation($"Class CEU {classCeu.Id} added");
                                ceuComplete = true;
                            }
                            else
                            {
                                _logger.LogError($"Failed to add Class CEU {classCeu.Id}");
                                return false;
                            }
                        }
                        else
                        {
                            ceuComplete = await _classCeuRepo.UpdateClassCeuAsync(classCeuModel);
                        }
                            
                        if (ceuComplete)
                        {
                            _logger.LogInformation($"Class CEU {classCeu.Id} updated");
                        }
                        else
                        {
                            _logger.LogError($"Failed to update Class CEU {classCeu.Id}");
                            return false;
                        }
                    }
                    _logger.LogInformation($"Training Class {trainingClass.Id} updated");
                    return true;
                }
                else
                {
                    _logger.LogError($"Failed to update Training Class {trainingClass.Id}");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
        }

        public async Task<TrainingClassView> GetTrainingClassByIdAsync(int id)
        {
            TrainingClass trainingClass = new TrainingClass();
            TrainingClassView trainingClassView = new TrainingClassView();

            try
            {
                trainingClass = await _trainingClassRepo.GetTrainingClassByIdAsync(id);
                if (trainingClass is not null)
                {
                    IEnumerable<ClassCeu> ceus = await _classCeuRepo.GetClassCeuForTrainingClassAsync(trainingClass.Id);
                    trainingClass.ClassCeus = ceus.ToList();


                    trainingClassView = TrainingClassMapper.MapToView(trainingClass);
                    foreach (var ceu in trainingClass.ClassCeus)
                    {
                        ClassCeuView classCeuView = ClassCeuMapper.MapToView(ceu);
                        trainingClassView.ClassCeus.Add(classCeuView);
                    }

                }

                return trainingClassView;
            }
            catch (SqlException ex)
            {
                _logger.LogError($"*****SQL Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"*****Exception*****");
                _logger.LogError(ex.Message);
                _logger.LogError("************************");
                throw;
            }

        }
    }
}
