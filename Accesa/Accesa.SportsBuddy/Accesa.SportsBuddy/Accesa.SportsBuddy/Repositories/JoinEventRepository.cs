using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public class JoinEventRepository : GenericRepository<JoinEvent>, IJoinEventRepository
    {

        public JoinEventRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public JoinEvent AddJoinEvent(JoinEvent joinEvent)
        {
            try
            {
                SportsBuddyDBContext.JoinEvents.Add(joinEvent);
                SportsBuddyDBContext.SaveChanges();
                return joinEvent;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding join event failed: {ex.Message}");
            }
        }

        public JoinEvent GetJoinEventByID(int userId, int eventId)
        {
            try
            {
                return SportsBuddyDBContext.JoinEvents.Include(je => je.Event)
                                                      .Include(je => je.User)
                                                      .SingleOrDefault(je => je.UserId == userId && je.EventId == eventId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting join event by ids failed: {ex.Message}");
            }
        }

        public IEnumerable<JoinEvent> GetJoinEvents()
        {
            try
            {
                return SportsBuddyDBContext.JoinEvents.Include(je => je.Event)
                                                       .ThenInclude(e => e.Address)
                                                      .Include(je => je.User)
                                                      .ThenInclude(u => u.Role);

            }
            catch (Exception ex)
            {
                throw new Exception($"Getting join events failed: {ex.Message}");
            }
        }

        public JoinEvent RemoveJoinEvent(JoinEvent joinEvent)
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