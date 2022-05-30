using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories
{
    public class JoinSportCenterEventRepository : GenericRepository<EventCreatedBySportCenter>, IJoinSportCenterEventRepository
    {

        public JoinSportCenterEventRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public JoinEventCreatedBySportCenter AddJoinEvent(JoinEventCreatedBySportCenter joinEvent)
        {
            try
            {
                SportsBuddyDBContext.JoinEventCreatedBySportCenters.Add(joinEvent);
                SportsBuddyDBContext.SaveChanges();
                return joinEvent;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding join event failed: {ex.Message}");
            }
        }

        public JoinEventCreatedBySportCenter GetJoinEventByID(int userId, int eventId)
        {
            try
            {
                return SportsBuddyDBContext.JoinEventCreatedBySportCenters.Include(je => je.Event)
                                                                          .Include(je => je.User)
                                                                          .SingleOrDefault(je => je.UserId == userId && je.EventId == eventId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting join event by ids failed: {ex.Message}");
            }
        }

        public IEnumerable<JoinEventCreatedBySportCenter> GetJoinEvents()
        {
            try
            {
                return SportsBuddyDBContext.JoinEventCreatedBySportCenters.Include(je => je.Event)
                                                                            .ThenInclude(je => je.Author)
                                                                            .ThenInclude(a => a.Role)
                                                                            .Include(je => je.Event)
                                                                            .ThenInclude(e => e.Address)
                                                                          .Include(je => je.User)
                                                                          .ThenInclude(u => u.Role);

            }
            catch (Exception ex)
            {
                throw new Exception($"Getting join events failed: {ex.Message}");
            }
        }

        public JoinEventCreatedBySportCenter RemoveJoinEvent(JoinEventCreatedBySportCenter joinEvent)
        {
            try
            {
                SportsBuddyDBContext.Remove(joinEvent);
                SportsBuddyDBContext.SaveChanges();
                return joinEvent;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deleting join event failed: {ex.Message}");
            }
        }
    }
}