using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface ITrainingProgramRepository : IGenericRepository<TrainingProgram>
    {
        IEnumerable<TrainingProgram> GetAllTrainingPrograms();

        TrainingProgram GetTrainingProgramById(int id);

        TrainingProgram AddTrainingProgram(TrainingProgram trainingProgram);

        TrainingProgram RemoveTrainingProgram(TrainingProgram trainingProgramID);

        TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram);

        bool ExistsSportCenter(TrainingProgram trainingProgram);

        TrainingProgram ReturnTrainingProgramById(int id);
    }
}