using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public interface IJoinEventRepository
    {
        IEnumerable<JoinEvent> GetJoinEvents();

        JoinEvent GetJoinEventByID(int userId, int eventId);

        JoinEvent AddJoinEvent(JoinEvent joinEvent);

        JoinEvent RemoveJoinEvent(JoinEvent joinEvent);
    }
}
