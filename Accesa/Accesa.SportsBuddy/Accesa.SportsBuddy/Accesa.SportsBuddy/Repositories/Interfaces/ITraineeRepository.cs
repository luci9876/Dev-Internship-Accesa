using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Database.Models
{
    public interface ITraineeRepository
    {
        IEnumerable<User> GetAllTrainees();
        User GetTraineeById(int id);
        User AddTrainee(User trainee);
        void DeleteTrainee(int id);
        User UpdateTrainee(User trainee);
        bool HasValidCredentials(UserCredentials info);
        IEnumerable<User> GetAllTraineesSortedByScore();

        User GetUserByEmail(string email);
    }
}