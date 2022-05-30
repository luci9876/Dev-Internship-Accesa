using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories
{
    public class TraineeRepository : GenericRepository<User>, ITraineeRepository
    {
        public TraineeRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public IEnumerable<User> GetAllTrainees()
        {
            try
            {
                return SportsBuddyDBContext.Users.Include(a => a.AddressNavigation)
                                                    .Include(r => r.Role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching trainees: {ex.Message}");
            }
        }

        public User GetTraineeById(int id)
        {
            try
            {
                var trainee = SportsBuddyDBContext.Users
                        .AsNoTracking()
                        .Include(t => t.Role)
                        .Include(a => a.AddressNavigation)
                        .SingleOrDefault(x => x.Id == id);
                return trainee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on fetching trainee with id {id}: {ex.Message}");
            }

        }

        public User UpdateTrainee(User trainee)
        {
            try
            {
                var role = SportsBuddyDBContext.Roles.SingleOrDefault(x => x.Id == trainee.Role.Id);
                trainee.Role = role;
                SportsBuddyDBContext.Users.Update(trainee);
                SportsBuddyDBContext.SaveChanges();
                return trainee;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error on updating trainee with id: {trainee.Id}- {ex.Message}");
            }
        }

        public User AddTrainee(User trainee)
        {
            try
            {
                var role = SportsBuddyDBContext.Roles.SingleOrDefault(x => x.Id == trainee.Role.Id);
                trainee.Role = role;
                SportsBuddyDBContext.Users.Add(trainee);
                SportsBuddyDBContext.SaveChanges();
                return trainee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on adding trainee: {ex.Message}");
            }

        }

        public void DeleteTrainee(int id)
        {
            try
            {
                var traineeForDeleteIndex = SportsBuddyDBContext?.Users?.SingleOrDefault(x => x.Id == id);
                SportsBuddyDBContext.Remove(traineeForDeleteIndex);
                SportsBuddyDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on deleting trainee: {ex.Message}");
            }
        }

        public bool HasValidCredentials(UserCredentials info)
        {
            try
            {
                var user = SportsBuddyDBContext?.Users?.SingleOrDefault(x => x.Email.ToLower().Equals(info.Email.ToLower()));
                return user != null && info.Password.Equals(user.Password);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error on processing request: {ex.Message}");
            }
        }

        public IEnumerable<User> GetAllTraineesSortedByScore()
        {
            try
            {
                return SportsBuddyDBContext.Users.Include(a => a.AddressNavigation)
                                                 .Include(r => r.Role)
                                                 .OrderByDescending(t => t.Score);                               
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching trainees: {ex.Message}");
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                var trainee = SportsBuddyDBContext.Users
                        .AsNoTracking()
                        .Include(t => t.Role)
                        .Include(a => a.AddressNavigation)
                        .SingleOrDefault(x => x.Email == email);
                return trainee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on fetching trainee with email {email}: {ex.Message}");
            }
        }
    }
}