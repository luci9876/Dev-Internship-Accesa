using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public Trainer AddTrainer(Trainer trainer)
        {
            try
            {
                if (trainer is null)
                {
                    throw new Exception("trainer is null");
                }
                var result = _trainerRepository.AddTrainer(trainer);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to add trainer: {ex.Message}");
            }
        }

        public void DeleteTrainer(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("The record doesn't exist");
                }
                _trainerRepository.DeleteTrainer(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to delete trainer: {ex.Message}");
            }
        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            var result = _trainerRepository.GetAllTrainers();
            return result;
        }

        public Trainer GetTrainerByEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception("email is null"); 
                }
                var result = _trainerRepository.GetTrainerByEmail(email);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to find trainer: {ex.Message}");
            }
        }

        public Trainer GetTrainerById(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new Exception("invalid id");
                }
                var result = _trainerRepository.GetTrainerById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to find trainer: {ex.Message}");
            }
        }

        public Trainer UpdateTrainer(Trainer trainer)
        {
            try
            {
                if(trainer is null)
                {
                    throw new Exception("Trainer is null");
                }
                var result = _trainerRepository.UpdateTrainer(trainer);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to update trainer: {ex.Message}");
            }
        }
    }
}
