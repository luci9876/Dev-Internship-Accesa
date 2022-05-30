using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories
{
    public class TrainerTrainingProgramRepository: GenericRepository<TrainerTrainingProgram>, ITrainerTrainingProgramRepository
    {
        public TrainerTrainingProgramRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfo()
        {
            return Context.TrainerTrainingPrograms
                .Include(t => t.Trainer)
                .ThenInclude(u => u.User)
                .Include(t => t.TrainingProgram)
                .ThenInclude(s => s.SportCenter)
                .ThenInclude(a => a.AddressNavigation);
        }
        public IEnumerable<TrainerTrainingProgram> GetTrainingsInfoByTrainerId(int id)
        {
            return Context.TrainerTrainingPrograms
                .Include(t => t.Trainer)
                .ThenInclude(u => u.User)
                .Include(t => t.TrainingProgram)
                .ThenInclude(s => s.SportCenter)
                .ThenInclude(a => a.AddressNavigation)
                .Where(t => t.TrainerId == id);
        }

        public TrainerTrainingProgram GetTrainingInfoById(int id)
        {
            return Context.TrainerTrainingPrograms
                .Include(t => t.Trainer)
                .ThenInclude(u => u.User)
                .Include(t => t.TrainingProgram)
                .ThenInclude(s => s.SportCenter)
                .ThenInclude(a => a.AddressNavigation)
                .SingleOrDefault(t => t.TrainingProgramId == id);
        }

        public void AddTrainerTrainingProgram(TrainerTrainingProgram trainerTrainingProgram)
        {
            if (trainerTrainingProgram == null)
                return;

            Context.TrainerTrainingPrograms.Add(trainerTrainingProgram);
            Context.SaveChanges();
        }

        public int GetTrainingProgramsCountByTrainerId(int id)

        {
            return Context.TrainerTrainingPrograms
                .Where(t => t.TrainerId == id)
                .Count();
        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }
    }
}
