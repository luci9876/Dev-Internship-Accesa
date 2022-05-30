using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ITrainerService 
    {
        IEnumerable<Trainer> GetAllTrainers();

        Trainer GetTrainerById(int id);

        Trainer AddTrainer(Trainer trainer);

        void DeleteTrainer(int id);
        Trainer UpdateTrainer(Trainer trainer);

        Trainer GetTrainerByEmail(string email);
    }
}
