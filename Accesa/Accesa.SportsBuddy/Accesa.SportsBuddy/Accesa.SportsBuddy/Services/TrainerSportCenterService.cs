using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class TrainerSportCenterService : ITrainerSportCenterService
    {
        private readonly ITrainerSportCenterRepository _trainerSportCenterRepository;

        public TrainerSportCenterService(ITrainerSportCenterRepository trainerSportCenterRepository)
        {
            _trainerSportCenterRepository = trainerSportCenterRepository;
        }
        public TrainerSportCenter AddNewTrainerToSportCenter(Trainer trainer, int sportCenterId)
        {
            var result = _trainerSportCenterRepository.AddNewTrainerToSportCenter(trainer, sportCenterId);
            return result;
        }

        public IEnumerable<TrainerSportCenter> GetAllTrainerSportCenter()
        {
            try
            {
                return _trainerSportCenterRepository.GetAllTrainerSportCenter();
            }

            catch (Exception ex)
            {
                throw new Exception($" Error:{ex.Message}");
            }
        }

        public TrainerSportCenter GetTrainersBySportCenterId(int id)
        {
            try
            {
                return _trainerSportCenterRepository.GetTrainersBySportCenterId(id);
            }

            catch (Exception ex)
            {
                throw new Exception($" Error:{ex.Message}");
            }
        }
    }
}
