using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IEventCreatedBySportCenterService
    {
        IEnumerable<EventCreatedBySportCenter> GetEvents();

        EventCreatedBySportCenter GetEventByID(int id);

        EventCreatedBySportCenter AddEvent(EventCreatedBySportCenter Event);

        EventCreatedBySportCenter RemoveEvent(int id);

        EventCreatedBySportCenter UpdateEvent(EventCreatedBySportCenter Event);

        IEnumerable<EventCreatedBySportCenter> GetEventByAuthor(int authorId);
    }
}