using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IAdministratedSportCenterRepository
    {
        IEnumerable<SportCenter> GetSportCentersByAdmin(int id);
        IEnumerable<SportCenterAdmin> GetSportCentersAdminsBySportCenter(int id);
        void AddAdminToSportCenter(int sportcenterid,int adminid);
        void DeleteBySportCenter(int id);
        void DeleteBySportCenterAdmin(int id);

    }
}
