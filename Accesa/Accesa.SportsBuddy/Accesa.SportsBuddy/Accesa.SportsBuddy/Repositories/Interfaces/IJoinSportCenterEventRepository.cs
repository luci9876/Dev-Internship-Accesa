using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IJoinSportCenterEventRepository
    {
        IEnumerable<JoinEventCreatedBySportCenter> GetJoinEvents();

        JoinEventCreatedBySportCenter GetJoinEventByID(int userId, int eventId);

        JoinEventCreatedBySportCenter AddJoinEvent(JoinEventCreatedBySportCenter joinEvent);

        JoinEventCreatedBySportCenter RemoveJoinEvent(JoinEventCreatedBySportCenter joinEvent);
    }
}
