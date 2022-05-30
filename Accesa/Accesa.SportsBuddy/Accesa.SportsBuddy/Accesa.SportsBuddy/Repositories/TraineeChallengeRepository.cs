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
    public class TraineeChallengeRepository : GenericRepository<TraineeChallenge>, ITraineeChallengeRepository
    {
        public TraineeChallengeRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public TraineeChallenge AddTraineeChallenge(TraineeChallenge traineeChallenge)
        {
            try
            {
                SportsBuddyDBContext.TraineeChallenges.Add(traineeChallenge);
                SportsBuddyDBContext.SaveChanges();
                return traineeChallenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding trainee challenge failed: {ex.Message}");
            }
        }

        public IEnumerable<TraineeChallenge> GetTraineeChallenges()
        {
            try
            {
                return SportsBuddyDBContext.TraineeChallenges.Include(tc => tc.Trainee)
                                                             .Include(tc => tc.Challenge);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting trainee challenges failed: {ex.Message}");
            }
        }


        public IEnumerable<TraineeChallenge> GetTraineeChallengesByTraineeId(int traineeId)
        {
            return Context.TraineeChallenges
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Challenge)
                .Where(t => t.TraineeId == traineeId);
        }

        public TraineeChallenge GetTraineeChallengeByID(int traineeID, int challengeID)
        {
            try
            {
                return SportsBuddyDBContext.TraineeChallenges.Include(tc => tc.Trainee)
                                                             .Include(tc => tc.Challenge)
                                                             .SingleOrDefault(tc => tc.ChallengeId == challengeID && tc.TraineeId == traineeID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting trainee challenge by ids failed: {ex.Message}");
            }
        }

        public TraineeChallenge RemoveTraineeChallenge(TraineeChallenge traineeChallenge)
        {
            try
            {
                SportsBuddyDBContext.Remove(traineeChallenge);
                SportsBuddyDBContext.SaveChanges();
                return traineeChallenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deleting trainee challenge failed: {ex.Message}");
            }
        }

        public TraineeChallenge UpdateTraineeChallenge(TraineeChallenge traineeChallenge)
        {
            try
            {
                SportsBuddyDBContext.TraineeChallenges.Update(traineeChallenge);
                SportsBuddyDBContext.SaveChanges();
                return traineeChallenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating trainee challenge failed: {ex.Message}");
            }
        }
    }
}