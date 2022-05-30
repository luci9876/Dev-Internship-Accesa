using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface IJoinEventService
    {
        IEnumerable<JoinEvent> GetJoinEvents();

        JoinEvent GetJoinEventByID(int userId, int eventId);

        JoinEvent AddJoinEvent(JoinEvent joinEvent);

        JoinEvent RemoveJoinEvent(int userId, int eventId);
    }
}