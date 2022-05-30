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
    public class ChallengeRepository : GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public Challenge AddChallenge(Challenge challenge)
        {
            try
            {
                SportsBuddyDBContext.Challenges.Add(challenge);
                SportsBuddyDBContext.SaveChanges();
                return challenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding challenge failed: {ex.Message}");
            }
        }

        public Challenge GetChallengeByID(int id)
        {
            try
            {
                return SportsBuddyDBContext.Challenges.SingleOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting challenge failed: {ex.Message}");
            }
        }

        public IEnumerable<Challenge> GetChallenges()
        {
            try
            {
                return SportsBuddyDBContext.Challenges.Include(c => c.Author);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting challenges failed: {ex.Message}");
            }
        }

        public Challenge RemoveChallenge(Challenge challenge)
        {
            try
            {
                SportsBuddyDBContext.Challenges.Remove(challenge);
                SportsBuddyDBContext.SaveChanges();
                return challenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deleting challenge failed: {ex.Message}");
            }
        }

        public Challenge UpdateChallenge(Challenge challenge)
        {
            try
            {
                SportsBuddyDBContext.Challenges.Update(challenge);
                SportsBuddyDBContext.SaveChanges();
                return challenge;
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating challenge failed: {ex.Message}");
            }
        }

        public IEnumerable<Challenge> GetChallengeByAuthor(int authorId)
        {
            try
            {
                return SportsBuddyDBContext.Challenges.Where(c => c.AuthorId == authorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting challenge failed: {ex.Message}");
            }
        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }
    }
}