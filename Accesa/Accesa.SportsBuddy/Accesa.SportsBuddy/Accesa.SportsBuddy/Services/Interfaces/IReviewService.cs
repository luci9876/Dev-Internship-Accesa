using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetReviewsByTrainingId(int id);

        public void AddReviewForUser(Review review);
    }
}
