using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class SportCenterAdminService : ISportCenterAdminService
    {
        private readonly ISportCenterAdminRepository _sportCenterAdminRepository;

        public SportCenterAdminService(ISportCenterAdminRepository sportCenterAdminRepository)
        {
            _sportCenterAdminRepository = sportCenterAdminRepository;
        }
        public SportCenterAdmin AddNewSportCenterAdmin(SportCenterAdmin sportCenterAdmin)
        {
            try
            {
                int roleId = sportCenterAdmin.RoleId;
                if (roleId < 1 || roleId > 3)
                {
                    throw new Exception("Invalid role id");
                }
                var result = _sportCenterAdminRepository.AddNewSportCenterAdmin(sportCenterAdmin);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding failed : {ex.Message}");
            }
        }

        public void DeleteSportCenterAdmin(int id)
        {
            try
            {
                var traineeForDeleteIndex = _sportCenterAdminRepository.GetSportCenterAdminById(id);
                if (traineeForDeleteIndex is null)
                {
                    throw new Exception("Invalid ID");
                }
                _sportCenterAdminRepository.DeleteSportCenterAdmin(traineeForDeleteIndex.Id);
            }
            catch (Exception)
            {
                throw new Exception("Delete failed");
            }
        }

        public SportCenterAdmin EditSportCenterAdmin(SportCenterAdmin sportCenterAdmin)
        {
            try
            {
                var oldSportCenterAdmin = _sportCenterAdminRepository.GetSportCenterAdminById(sportCenterAdmin.Id);
                if (oldSportCenterAdmin == null)
                {
                    throw new Exception("The record doesn't exist");
                }
                if (oldSportCenterAdmin.RoleId < 1 || oldSportCenterAdmin.RoleId > 3)
                {
                    throw new Exception("Invalid role id");
                }
                oldSportCenterAdmin.Name = sportCenterAdmin.Name;
                oldSportCenterAdmin.Email = sportCenterAdmin.Email;
                oldSportCenterAdmin.Password = sportCenterAdmin.Password;
                oldSportCenterAdmin.PhoneNumber = sportCenterAdmin.PhoneNumber;
                oldSportCenterAdmin.Birthdate = sportCenterAdmin.Birthdate;
                oldSportCenterAdmin.RoleId = sportCenterAdmin.RoleId;
                var result = _sportCenterAdminRepository.EditSportCenterAdmin(oldSportCenterAdmin);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public IEnumerable<SportCenterAdmin> GetAllSportCenterAdmins()
        {
            try
            {
                return _sportCenterAdminRepository.GetAllSportCenterAdmins();
            }
            catch (Exception)
            {
                throw new Exception("Get admins failed");
            }
        }

        public SportCenterAdmin GetSportCenterAdminById(int id)
        {
            try
            {
                var admin = _sportCenterAdminRepository.GetSportCenterAdminById(id);
                if (admin == null)
                {
                    throw new Exception("invalid id");
                }
                return admin;
            }
            catch (Exception)
            {
                throw new Exception("The record doesn't exist");
            }
        }

        public bool LoginAsSportCenterAdmin(AdminLoginInfo adminLoginInfo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(adminLoginInfo.Email))
                {
                    throw new Exception("Email can't be empty");
                }
                if (string.IsNullOrWhiteSpace(adminLoginInfo.Password))
                {
                    throw new Exception("Password can't be empty");
                }
                var result = _sportCenterAdminRepository.LoginAsSportCenterAdmin(adminLoginInfo);
                return result;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        public SportCenterAdmin GetSportCenterAdminByEmail(string email)
        {
            try
            {
                var admin = _sportCenterAdminRepository.GetSportCenterAdminByEmail(email);
                if (admin == null)
                {
                    throw new Exception("invalid email");
                }
                return admin;
            }
            catch (Exception)
            {
                throw new Exception("The record doesn't exist");
            }
        }
    }
}
