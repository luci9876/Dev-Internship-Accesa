using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IUserTrainingService
    {
        public IEnumerable<TrainingProgram> GetAllTrainingPrograms();
        public TrainingProgram GetTrainingProgramById(int id);
        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram);
        public TrainingProgram AddTrainingProgram(TrainingProgramDTO trainingProgram);
        public void DeleteTrainingProgram(int id);

    }
}
