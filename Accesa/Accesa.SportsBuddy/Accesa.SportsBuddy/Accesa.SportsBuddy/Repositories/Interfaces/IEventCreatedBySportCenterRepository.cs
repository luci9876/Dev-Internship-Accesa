using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IEventCreatedBySportCenterRepository
    {
        IEnumerable<EventCreatedBySportCenter> GetEvents();

        EventCreatedBySportCenter GetEventByID(int id);

        EventCreatedBySportCenter AddEvent(EventCreatedBySportCenter Event);

        EventCreatedBySportCenter RemoveEvent(EventCreatedBySportCenter Event);

        EventCreatedBySportCenter UpdateEvent(EventCreatedBySportCenter Event);

        IEnumerable<EventCreatedBySportCenter> GetEventByAuthor(int authorId);
    }
}