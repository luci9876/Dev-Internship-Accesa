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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public IEnumerable<Review> GetReviewsByTrainingId(int id)
        {
            return Context.Reviews
                .Include(u => u.Trainee)
                .Where(r => r.TrainingId == id)
                .OrderBy(r => r.CreatedAt);
        }

        public void AddReviewForUser(Review review)
        {
            if (review == null)
                return;

            Context.Add(review);
            Context.SaveChanges();
        }

        public int GetReviewsCountByTrainingId(int id)

        {
            return Context.Reviews
                .Where(r => r.TrainingId == id)
                .Count();
        }
    }
}
