using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IJoinSportCenterEventService
    {
        IEnumerable<JoinEventCreatedBySportCenter> GetJoinEvents();

        JoinEventCreatedBySportCenter GetJoinEventByID(int userId, int eventId);

        JoinEventCreatedBySportCenter AddJoinEvent(JoinEventCreatedBySportCenter joinEvent);

        JoinEventCreatedBySportCenter RemoveJoinEvent(int userId, int eventId);
    }
}
