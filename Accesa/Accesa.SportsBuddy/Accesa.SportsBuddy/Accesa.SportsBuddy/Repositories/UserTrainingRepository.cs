using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories
{
    public class UserTrainingRepository : GenericRepository<TrainingProgram>, IUserTrainingRepository
    {
        public UserTrainingRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<TrainingProgram> GetAllTrainingPrograms()
        {
            try
            {
                return SportsBuddyDBContext.TrainingPrograms
                    .Include(r => r.Reviews);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching training programs: {ex.Message}");
            }
        }
        public TrainingProgram GetTrainingProgramById(int id)
        {
            try 
            {
                return SportsBuddyDBContext.TrainingPrograms
                    .Include(r => r.Reviews)
                    .SingleOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on fetching training program with id {id}: {ex.Message}");
            }
        }

        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                SportsBuddyDBContext.TrainingPrograms.Update(trainingProgram);
                SportsBuddyDBContext.SaveChanges();
                return trainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on updating training program with id: {trainingProgram.Id}- {ex.Message}");
            }
        }

        public TrainingProgram AddTrainingProgram(TrainingProgramDTO trainingProgram)
        {
            try
            {
                if (trainingProgram == null)
                    return null;

                TrainingProgram newTrainingProgram = new()
                {
                    Name = trainingProgram.Name,
                    Difficulty = trainingProgram.Difficulty,
                    RecommendedSteps = trainingProgram.RecommendedSteps,
                    SportCenterId = trainingProgram.SportCenterId,
                    Duration = trainingProgram.Duration,
                };

                SportsBuddyDBContext.TrainingPrograms.Add(newTrainingProgram);
                Context.SaveChanges();
                return newTrainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on adding trainee: {ex.Message}");
            }
        }

        public bool DeleteTrainingProgram(int id)
        {
            try
            {
                var trainingProgram = Context.TrainingPrograms
                    .SingleOrDefault(u => u.Id == id);

                if (trainingProgram != null)
                {
                    SportsBuddyDBContext.TrainingPrograms.Remove(trainingProgram);
                    Context.SaveChanges();
                    return true;
                }

                return false;
            }

            catch (Exception ex)
            {
                throw new Exception($"Error on deleting training program: {ex.Message}");
            }
        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }
    }
}
