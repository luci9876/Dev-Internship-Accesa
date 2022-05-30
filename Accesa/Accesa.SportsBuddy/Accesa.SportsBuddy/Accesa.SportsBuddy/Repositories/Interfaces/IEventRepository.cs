using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();

        Event GetEventByID(int id);

        Event AddEvent(Event Event);

        Event RemoveEvent(Event Event);

        Event UpdateEvent(Event Event);

        IEnumerable<Event> GetEventByAuthor(int authorId);
    }
}