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
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository

    {
        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }

        }

        public TrainerRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            try
            {
                return SportsBuddyDBContext.Trainers
                    .Include(u => u.User)
                    .ThenInclude(a => a.AddressNavigation)
                    .Include(u => u.User)
                    .ThenInclude(a => a.Role);
            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to get trainers {ex.Message}");
            }
        }

        public Trainer GetTrainerById(int id)
        {
            try
            {
                return SportsBuddyDBContext.Trainers
                    .Include(u => u.User)
                    .ThenInclude(a => a.AddressNavigation)
                    .Include(u => u.User)
                    .ThenInclude(a => a.Role)
                    .SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get trainer: {ex.Message}");
            }
        }

        public Trainer AddTrainer(Trainer trainer)
        {
            try
            {
                if(trainer is null)
                {
                    throw new Exception("trainer is null");
                }
                SportsBuddyDBContext.Trainers.Add(trainer);
                SportsBuddyDBContext.SaveChanges();
                return trainer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to add trainer: {ex.Message}");
            }
        }

        public Trainer UpdateTrainer(Trainer trainer)
        {
            try
            {
                SportsBuddyDBContext.Trainers.Update(trainer);
                SportsBuddyDBContext.SaveChanges();
                return trainer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to update trainer: {ex.Message}");
            }
        }

        public void DeleteTrainer(int id)
        {
            try
            {
                var trainerForDeleteIndex = SportsBuddyDBContext?.Trainers.SingleOrDefault(x => x.Id == id);
                SportsBuddyDBContext.Trainers.Remove(trainerForDeleteIndex);
                SportsBuddyDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to delete trainer: {ex.Message}");
            }
        }

        public Trainer GetTrainerByEmail(string email)
        {
            try
            {
                var user = SportsBuddyDBContext.Users.SingleOrDefault(u => u.Email == email);
                return SportsBuddyDBContext.Trainers
                    .Include(u => u.User)
                    .ThenInclude(a => a.AddressNavigation)
                    .Include(u => u.User)
                    .ThenInclude(a => a.Role)
                    .SingleOrDefault(x => x.UserId == user.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to find trainer: {ex.Message}");
            }
        }
    }
}
