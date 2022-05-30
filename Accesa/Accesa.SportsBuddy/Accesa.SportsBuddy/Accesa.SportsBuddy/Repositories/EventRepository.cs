using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {

        public EventRepository(SportsBuddyDBContext dbContext) : base(dbContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public Event AddEvent(Event Event)
        {
            try
            {
                var role = SportsBuddyDBContext.Roles.SingleOrDefault(r => r.Id == Event.Author.Role.Id);
                if (role is null)
                {
                    throw new Exception("Role could not be found.");
                }
                var user = SportsBuddyDBContext.Users.SingleOrDefault(x => x.Id == Event.AuthorId);
                if (user is null)
                {
                    throw new Exception("User could not be found.");
                }
                user.Role = role;
                Event.Author = user;
                SportsBuddyDBContext.Events.Add(Event);
                SportsBuddyDBContext.SaveChanges();
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding event failed: {ex.Message}");
            }
        }

        public Event GetEventByID(int id)
        {
            try
            {
                return SportsBuddyDBContext.Events.Include(e => e.Address)
                                                  .Include(e => e.Author)
                                                  .SingleOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting event failed: {ex.Message}");
            }
        }

        public IEnumerable<Event> GetEvents()
        {
            try
            {
                return SportsBuddyDBContext.Events.Include(e => e.Address)
                                                  .Include(e => e.Author)
                                                  .ThenInclude(e=> e.Role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting events failed: {ex.Message}");
            }
        }

        public Event RemoveEvent(Event Event)
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

        public Event UpdateEvent(Event Event)
        {
            try
            {
                SportsBuddyDBContext.Events.Update(Event);
                SportsBuddyDBContext.SaveChanges();
                return Event;
            }
            catch (Exception ex)
            {
                throw new Exception($"Updating event failed: {ex.Message}");
            }
        }

        public IEnumerable<Event> GetEventByAuthor(int authorId)
        {
            try
            {
                return SportsBuddyDBContext.Events.Include(e => e.Address)
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