using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Mapper;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Accesa.SportsBuddy.Repositories
{
    public class AdministratedSportCenterRepository : GenericRepository<AdministratedSportCenterRepository>, IAdministratedSportCenterRepository
    {
        public AdministratedSportCenterRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }
        
        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public void AddAdminToSportCenter(int sportCenterId, int adminId)
        {
            try
            {
                var resultSportCenter = SportsBuddyDBContext.SportCenters.Where(s => s.Id == sportCenterId).SingleOrDefault();
                var resultAdmin = SportsBuddyDBContext.SportCenterAdmins.Where(s => s.Id == adminId).SingleOrDefault();
                if (resultAdmin == null || resultSportCenter == null)
                {
                    throw new Exception("Admin or Sport Center is null");
                }
                AdministratedSportCenter administratedSportCenter = new AdministratedSportCenter();
                administratedSportCenter.SportCenterAdminId = adminId;
                administratedSportCenter.SportCenterId = sportCenterId;
                SportsBuddyDBContext.Add(administratedSportCenter);
                SportsBuddyDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public void DeleteBySportCenter(int id)
        {
            try
            {
                var results = SportsBuddyDBContext.AdministratedSportCenters.Where(s => s.SportCenterId == id).ToList();
                if (results.Count() > 0)
                {
                    SportsBuddyDBContext.RemoveRange(results);
                    SportsBuddyDBContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBySportCenterAdmin(int id)
        {
            try
            {
                var results = SportsBuddyDBContext.AdministratedSportCenters.Where(s => s.SportCenterAdminId == id).ToList();
                if (results.Count() > 0)
                {
                    SportsBuddyDBContext.RemoveRange(results);
                    SportsBuddyDBContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SportCenterAdmin> GetSportCentersAdminsBySportCenter(int id)
        {
            try
            {
                var results = SportsBuddyDBContext.AdministratedSportCenters.Where(a => a.SportCenterId == id).ToList();
                var list = new List<SportCenterAdmin>();
                foreach (var r in results)
                {
                    int currentId = r.SportCenterAdminId;
                    list.Add(SportsBuddyDBContext.SportCenterAdmins.Include(s => s.Role).Where(s => s.Id == currentId).FirstOrDefault());
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SportCenter> GetSportCentersByAdmin(int id)
        {
            try
            {
                var results = SportsBuddyDBContext.AdministratedSportCenters.Where(a => a.SportCenterAdminId == id).ToList();
                var list = new List<SportCenter>();
                foreach (var r in results)
                {
                    int currentId = r.SportCenterId;
                    list.Add(SportsBuddyDBContext.SportCenters.Include(s => s.AddressNavigation).Where(s => s.Id == currentId).FirstOrDefault());
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
