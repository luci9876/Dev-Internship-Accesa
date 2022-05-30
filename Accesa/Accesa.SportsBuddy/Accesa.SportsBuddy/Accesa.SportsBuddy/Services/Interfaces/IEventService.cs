using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();

        Event GetEventByID(int id);

        Event AddEvent(Event Event);

        Event RemoveEvent(int id);

        Event UpdateEvent(Event Event);

        IEnumerable<Event> GetEventByAuthor(int authorId);
    }
}