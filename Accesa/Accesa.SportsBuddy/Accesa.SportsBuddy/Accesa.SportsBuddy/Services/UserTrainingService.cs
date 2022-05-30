using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Accesa.SportsBuddy.Services
{
    public class UserTrainingService : IUserTrainingService
    {
        private readonly IUserTrainingRepository _userTrainingRepository;
        public UserTrainingService(IUserTrainingRepository userTrainingRepository)
        {
            _userTrainingRepository = userTrainingRepository;
        }
        public TrainingProgram AddTrainingProgram(TrainingProgramDTO trainingProgram)
        {
            try
            {
                TrainingProgram result = _userTrainingRepository.AddTrainingProgram(trainingProgram);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Adding failed:{ex.Message}");
            }
        }

        public void DeleteTrainingProgram(int id)
        {
            try
            {
                var userTrainingRepository = _userTrainingRepository.GetTrainingProgramById(id);
                if (userTrainingRepository is null)
                {
                    throw new Exception("Invalid ID");
                }
                _userTrainingRepository.DeleteTrainingProgram(userTrainingRepository.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete failed {ex.Message}");
            }
        }

        public IEnumerable<TrainingProgram> GetAllTrainingPrograms()
        {
            try
            {
                return _userTrainingRepository.GetAllTrainingPrograms();
            }
            catch (Exception ex)
            {
                throw new Exception($"Get failed : {ex.Message}");
            }
        }

        public TrainingProgram GetTrainingProgramById(int id)
        {
            try
            {
                var trainingProgram = _userTrainingRepository.GetTrainingProgramById(id);
                if(trainingProgram == null)
                {
                    throw new Exception("invalid id");
                }
                return trainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"The record doesn't exist :{ex.Message}");
            }
        }

        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                var trainingProgramForUpdate = _userTrainingRepository.GetTrainingProgramById(trainingProgram.Id);
                if (trainingProgramForUpdate == null)
                {
                    throw new Exception("The record doesn't exist");
                }
                trainingProgramForUpdate.Name = trainingProgram.Name;
                trainingProgramForUpdate.Difficulty = trainingProgram.Difficulty;
                trainingProgramForUpdate.RecommendedSteps = trainingProgram.RecommendedSteps;
                trainingProgramForUpdate.SportCenterId = trainingProgram.SportCenterId;
                trainingProgramForUpdate.Duration = trainingProgram.Duration;
                var result = _userTrainingRepository.UpdateTrainingProgram(trainingProgramForUpdate);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed:{ex.Message}");
            }
        }
    }
}
