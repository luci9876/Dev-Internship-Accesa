using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface ITrainerSportCenterRepository
    {
        public IEnumerable<TrainerSportCenter> GetAllTrainerSportCenter();

        public TrainerSportCenter GetTrainersBySportCenterId(int id);

        public TrainerSportCenter AddNewTrainerToSportCenter(Trainer trainer, int sportCenterId);

    }
}

