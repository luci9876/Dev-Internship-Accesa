using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accesa.SportsBuddy.DTO;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface ISportCenterRepository
    {
        SportCenter GetSportCenterById(int id);
        void DeleteSportCenterById(int id);
        SportCenterDTO CreateSportCenter(SportCenterDTO sportcenterdto);
        void EditSportCenter(int id, SportCenterDTO sportcenterdto);
        IEnumerable<SportCenter> GetAllSportCenters();

    }
}
