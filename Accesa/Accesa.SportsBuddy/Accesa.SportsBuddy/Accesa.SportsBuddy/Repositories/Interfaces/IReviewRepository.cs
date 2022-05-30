using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetReviewsByTrainingId(int id);

        public void AddReviewForUser(Review review);
        public int GetReviewsCountByTrainingId(int id);
    }
}
