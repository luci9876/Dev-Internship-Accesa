using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accesa.SportsBuddy.Repositories
{

    public class TrainingProgramRepository : GenericRepository<TrainingProgram>, ITrainingProgramRepository
    {
        public TrainingProgramRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public IEnumerable<TrainingProgram> GetAllTrainingPrograms()
        {
            try
            {
                return SportsBuddyDBContext.TrainingPrograms.Include(t => t.SportCenter)
                                                            .ThenInclude(sc => sc.AddressNavigation);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting training programs failed: {ex.Message}");
            }
        }

        public TrainingProgram GetTrainingProgramById(int id)
        {
            try
            {
                return SportsBuddyDBContext.TrainingPrograms.Include(t => t.SportCenter)
                                                            .ThenInclude(sc => sc.AddressNavigation)
                                                            .SingleOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting training program failed: {ex.Message}");
            }

        }

        public TrainingProgram AddTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                SportsBuddyDBContext.TrainingPrograms.Add(trainingProgram);
                SportsBuddyDBContext.SaveChanges();
                return trainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding training program failed: {ex.Message}");
            }
        }

        public TrainingProgram RemoveTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                SportsBuddyDBContext.Remove(trainingProgram);
                SportsBuddyDBContext.SaveChanges();
                return trainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deleting training program failed: {ex.Message}");
            }
        }

        public TrainingProgram UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                var oldTraining = Context.TrainingPrograms
                    .SingleOrDefault(t => t.Id == trainingProgram.Id);

                if (oldTraining != null)
                {
                    oldTraining.Name = trainingProgram.Name;
                    oldTraining.Description = trainingProgram.Description;
                    oldTraining.Difficulty = trainingProgram.Difficulty;
                    oldTraining.Location = trainingProgram.Location;
                    oldTraining.RecommendedSteps = trainingProgram.RecommendedSteps;
                    oldTraining.Rating = trainingProgram.Rating;
                    oldTraining.Duration = trainingProgram.Duration;
                    if (trainingProgram.SportCenterId > 0)
                        oldTraining.SportCenterId = trainingProgram.SportCenterId;
                    SportsBuddyDBContext.SaveChanges();
                }
                return trainingProgram;
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating training program failed: {ex.Message}");
            }
        }

        public bool ExistsSportCenter(TrainingProgram trainingProgram)
        {
            try
            {
                var sportCenter = SportsBuddyDBContext.SportCenters.SingleOrDefault(s => s.Id == trainingProgram.SportCenterId);
                if (sportCenter == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Extracting sport center from training program failed: {ex.Message}");
            }
        }

        public TrainingProgram ReturnTrainingProgramById(int id)
        {
            try
            {
                return SportsBuddyDBContext.TrainingPrograms.SingleOrDefault(t => t.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to retrieve training program with this id : {ex.Message}");
            }
        }
    }
}