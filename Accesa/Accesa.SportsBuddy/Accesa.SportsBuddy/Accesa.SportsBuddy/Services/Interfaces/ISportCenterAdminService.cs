using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ISportCenterAdminService
    {
        public IEnumerable<SportCenterAdmin> GetAllSportCenterAdmins();

        public SportCenterAdmin GetSportCenterAdminById(int id);

        public SportCenterAdmin EditSportCenterAdmin(SportCenterAdmin sportCenterAdmin);

        public SportCenterAdmin AddNewSportCenterAdmin(SportCenterAdmin sportCenterAdmin);

        public bool LoginAsSportCenterAdmin(AdminLoginInfo adminLoginInfo);

        public void DeleteSportCenterAdmin(int id);

        public SportCenterAdmin GetSportCenterAdminByEmail(string email);
    }
}
