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
    public class EventCreatedBySportCenterRepository : GenericRepository<EventCreatedBySportCenter>, IEventCreatedBySportCenterRepository
    {

        public EventCreatedBySportCenterRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public EventCreatedBySportCenter AddEvent(EventCreatedBySportCenter Event)
        {
            try
            {
                var role = SportsBuddyDBContext.Roles.SingleOrDefault(r => r.Id == Event.Author.Role.Id);
                if (role is null)
                {
                    throw new Exception("Role could not be found.");
                }
                var user = SportsBuddyDBContext.SportCenterAdmins.Include(r => r.Role).SingleOrDefault(x => x.Id == Event.AuthorId);
                if(user is null)
                {
                    throw new Exception("User could not be found.");
                }
                user.Role = role;
                Event.Author = user;
                SportsBuddyDBContext.EventCreatedBySportCenters.Add(Event);
                SportsBuddyDBContext.SaveChanges();
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding event failed: {ex.Message}");
            }
        }

        public EventCreatedBySportCenter GetEventByID(int id)
        {
            try
            {
                return SportsBuddyDBContext.EventCreatedBySportCenters.Include(e => e.Address)
                                                                      .Include(e => e.Author)
                                                                      .SingleOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting event failed: {ex.Message}");
            }
        }

        public IEnumerable<EventCreatedBySportCenter> GetEvents()
        {
            try
            {
                return SportsBuddyDBContext.EventCreatedBySportCenters.Include(e => e.Address)
                                                                      .Include(e => e.Author)
                                                                      .ThenInclude(e => e.Role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting events failed: {ex.Message}");
            }
        }

        public EventCreatedBySportCenter RemoveEvent(EventCreatedBySportCenter Event)
        {
            try
            {
                SportsBuddyDBContext.Remove(Event);
                SportsBuddyDBContext.SaveChanges();
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deleting event failed: {ex.Message}");
            }
        }

        public EventCreatedBySportCenter UpdateEvent(EventCreatedBySportCenter Event)
        {
            try
            {
                SportsBuddyDBContext.EventCreatedBySportCenters.Update(Event);
                SportsBuddyDBContext.SaveChanges();
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating event failed: {ex.Message}");
            }
        }

        public IEnumerable<EventCreatedBySportCenter> GetEventByAuthor(int authorId)
        {
            try
            {
                return SportsBuddyDBContext.EventCreatedBySportCenters.Include(e => e.Address)
                                                                      .Include(e => e.Author)
                                                                      .ThenInclude(a => a.Role)
                                                                      .Where(c => c.AuthorId == authorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting event failed: {ex.Message}");
            }
        }
    }
}