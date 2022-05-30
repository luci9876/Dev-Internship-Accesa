using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITrainerTrainingProgramService
    {
        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfo();
        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfoByTrainerId(int id);
        public TrainerTrainingProgram GetTrainingInfoById(int id);
        public void AddTrainerTrainingProgram(TrainerTrainingProgram trainerTrainingProgram);
        public int GetTrainingProgramsCountByTrainerId(int id);
    }
}
