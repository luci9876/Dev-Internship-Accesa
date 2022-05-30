using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System.Collections.Generic;

namespace Accesa.SportsBuddy.Services
{
    public class TrainerTrainingProgramService : ITrainerTrainingProgramService
    {
        private readonly ITrainerTrainingProgramRepository _trainerTrainingProgramRepository;
        private readonly ITrainingProgramService _trainingProgramService;
        private readonly ITrainerRepository _trainerRepository;

        public TrainerTrainingProgramService(ITrainerTrainingProgramRepository trainerTrainingProgramRepository, ITrainingProgramService trainingProgramService, ITrainerRepository trainerRepository)
        {
            _trainerTrainingProgramRepository = trainerTrainingProgramRepository;
            _trainingProgramService = trainingProgramService;
            _trainerRepository = trainerRepository;
        }

        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfo()
        {
            return _trainerTrainingProgramRepository.GetTrainingsInfo();
        }

        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfoByTrainerId(int id)
        {
            return _trainerTrainingProgramRepository.GetTrainingsInfoByTrainerId(id);
        }
        public TrainerTrainingProgram GetTrainingInfoById(int id)
        {
            return _trainerTrainingProgramRepository.GetTrainingInfoById(id);
        }

        public int GetTrainingProgramsCountByTrainerId(int id)
        {
            return _trainerTrainingProgramRepository.GetTrainingProgramsCountByTrainerId(id);
        }

        public void AddTrainerTrainingProgram(TrainerTrainingProgram trainerTrainingProgram)
        {
            _trainerTrainingProgramRepository.AddTrainerTrainingProgram(trainerTrainingProgram);

            var trainingsCount = _trainerTrainingProgramRepository.GetTrainingProgramsCountByTrainerId(trainerTrainingProgram.TrainerId);
            var training = _trainingProgramService.GetTrainingProgramById(trainerTrainingProgram.TrainingProgramId);
            var trainer = _trainerRepository.GetTrainerById(trainerTrainingProgram.TrainerId);
            trainer.Rating = (decimal)(trainer.Rating * (trainingsCount - 1) + training.Rating) / trainingsCount;
            _trainerRepository.UpdateTrainer(trainer);
        }
    }
}
