using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using System.Collections.Generic;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IUserTrainingRepository
    {
        IEnumerable<TrainingProgram> GetAllTrainingPrograms();

        public TrainingProgram GetTrainingProgramById(int id);

        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram);

        public TrainingProgram AddTrainingProgram(TrainingProgramDTO trainingProgram);

        public bool DeleteTrainingProgram(int id);
    }
}
