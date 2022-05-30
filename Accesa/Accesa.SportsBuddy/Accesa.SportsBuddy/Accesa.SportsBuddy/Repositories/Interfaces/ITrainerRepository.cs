using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Controllers;
using Accesa.SportsBuddy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        IEnumerable<Trainer> GetAllTrainers();

        Trainer GetTrainerById(int id);

        Trainer AddTrainer(Trainer trainer);

        void DeleteTrainer(int id);
        Trainer UpdateTrainer(Trainer trainer);

        Trainer GetTrainerByEmail(string email);

    }
}