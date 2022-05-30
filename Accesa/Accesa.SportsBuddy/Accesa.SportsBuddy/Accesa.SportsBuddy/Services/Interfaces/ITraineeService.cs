using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITraineeService
    {
        IEnumerable<User> GetAllTrainees();
        User GetTraineeById(int id);
        User AddTrainee(User trainee);
        void DeleteTrainee(int id);
        User UpdateTrainee(User trainee);
        bool HasValidCredentials(UserCredentials info);
        User UpdateUserScore(int id);
        IEnumerable<User> GetAllTraineesSortedByScore();
        User GetUserByEmail(string email);
    }
}