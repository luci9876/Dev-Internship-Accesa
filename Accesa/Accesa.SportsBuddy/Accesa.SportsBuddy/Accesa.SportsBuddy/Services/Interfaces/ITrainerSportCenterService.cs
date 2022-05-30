using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITrainerSportCenterService
    {
        public IEnumerable<TrainerSportCenter> GetAllTrainerSportCenter();

        public TrainerSportCenter GetTrainersBySportCenterId(int id);

        public TrainerSportCenter AddNewTrainerToSportCenter(Trainer trainer, int sportCenterId);
    }
}
