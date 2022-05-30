using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITrainingProgramService
    {
        IEnumerable<TrainingProgram> GetAllTrainingPrograms();

        TrainingProgram GetTrainingProgramById(int id);

        TrainingProgram AddTrainingProgram(TrainingProgram trainingProgram);

        TrainingProgram RemoveTrainingProgram(int trainingProgramID);

        TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram);
    }
}
