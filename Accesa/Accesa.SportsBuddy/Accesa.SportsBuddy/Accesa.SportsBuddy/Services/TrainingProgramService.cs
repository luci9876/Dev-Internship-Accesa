using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class TrainingProgramService : ITrainingProgramService
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        public TrainingProgramService(ITrainingProgramRepository trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }

        public TrainingProgram AddTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                return _trainingProgramRepository.AddTrainingProgram(trainingProgram);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }
        }

        public IEnumerable<TrainingProgram> GetAllTrainingPrograms()
        {
            try
            {
                return _trainingProgramRepository.GetAllTrainingPrograms();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public TrainingProgram GetTrainingProgramById(int id)
        {
            try
            {
                return _trainingProgramRepository.GetTrainingProgramById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public TrainingProgram RemoveTrainingProgram(int trainingProgramID)
        {
            try
            {
                TrainingProgram trainingProgram = _trainingProgramRepository.ReturnTrainingProgramById(trainingProgramID);
                if (trainingProgram == null)
                {
                    throw new Exception("Training program with this id doesn't exists!");
                }
                return _trainingProgramRepository.RemoveTrainingProgram(trainingProgram);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }

        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                if (trainingProgram == null)
                    throw new Exception("Training program is null!");

                return _trainingProgramRepository.UpdateTrainingProgram(trainingProgram);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update operation failed! {ex.Message}");
            }
        }
    }
}