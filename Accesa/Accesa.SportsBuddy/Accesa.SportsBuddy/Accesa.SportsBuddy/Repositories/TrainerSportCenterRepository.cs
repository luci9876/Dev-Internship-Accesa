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
    public class TrainerSportCenterRepository : GenericRepository<TrainerSportCenterRepository>, ITrainerSportCenterRepository
    {
        public TrainerSportCenterRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {
        }
        public TrainerSportCenter AddNewTrainerToSportCenter(Trainer trainer, int sportCenterId)
        {
            if (trainer == null)
                throw new Exception();

            TrainerSportCenter newTrainerSportCenter = new()
            {
                TrainerId = trainer.Id,
                SportCenterId = sportCenterId
            };

            Context.TrainerSportCenters.Add(newTrainerSportCenter);
            Context.SaveChanges();
            return newTrainerSportCenter;
        }

        public IEnumerable<TrainerSportCenter> GetAllTrainerSportCenter()
        {
            return Context.TrainerSportCenters.Include(t => t.Trainer);
        }

        public TrainerSportCenter GetTrainersBySportCenterId(int id)
        {
            return Context.TrainerSportCenters
                .Include(t => t.Trainer)
                .SingleOrDefault(u => u.Id == id);
        }
    }
}
