using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories
{
    public class SportCenterAdminRepository : GenericRepository<SportCenterAdmin>, ISportCenterAdminRepository
    {
        public SportCenterAdminRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<SportCenterAdmin> GetAllSportCenterAdmins()
        {
            return SportsBuddyDBContext.SportCenterAdmins
                .Include(r => r.Role);
        }

        public SportCenterAdmin GetSportCenterAdminById(int id)
        {
            return SportsBuddyDBContext.SportCenterAdmins
                .Include(r => r.Role)
                .SingleOrDefault(u => u.Id == id);
        }

        public SportCenterAdmin EditSportCenterAdmin(SportCenterAdmin sportCenterAdmin)
        {
            try
            {
                SportsBuddyDBContext.SportCenterAdmins.Update(sportCenterAdmin);
                SportsBuddyDBContext.SaveChanges();
                return sportCenterAdmin;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on updating admin with id: {sportCenterAdmin.Id}: {ex.Message}");
            }
        }


        public SportCenterAdmin AddNewSportCenterAdmin(SportCenterAdmin sportCenterAdmin)
        {
            try
            {
                var role = SportsBuddyDBContext.Roles.SingleOrDefault(x => x.Id == sportCenterAdmin.Role.Id);
                sportCenterAdmin.Role = role;
                SportsBuddyDBContext.SportCenterAdmins.Add(sportCenterAdmin);
                SportsBuddyDBContext.SaveChanges();
                return sportCenterAdmin;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on adding admin: {ex.Message}");
            }
        }

        public bool LoginAsSportCenterAdmin(AdminLoginInfo adminLoginInfo)
        {
            try
            {
                var user = SportsBuddyDBContext?.Users?.SingleOrDefault(x => x.Email.ToLower().Equals(adminLoginInfo.Email.ToLower()));
                return user != null && adminLoginInfo.Password.Equals(user.Password);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on processing request: {ex.Message}");
            }
        }

        public void DeleteSportCenterAdmin(int id)
        {
            try
            {
                var adminForDeleteIndex = SportsBuddyDBContext?.Users?.SingleOrDefault(x => x.Id == id);
                SportsBuddyDBContext.Remove(adminForDeleteIndex);
                SportsBuddyDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on deleting trainee: {ex.Message}");
            }
        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public SportCenterAdmin GetSportCenterAdminByEmail(string email)
        {
            return SportsBuddyDBContext.SportCenterAdmins
                .Include(r => r.Role)
                .SingleOrDefault(u => u.Email == email);
        }
    }
}
