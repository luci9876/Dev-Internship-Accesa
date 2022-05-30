using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class JoinSportCenterEventService : IJoinSportCenterEventService
    {

        private readonly IJoinSportCenterEventRepository _joinSportCenterEventRepository;

        public JoinSportCenterEventService(IJoinSportCenterEventRepository joinSportCenterEventRepository)
        {
            _joinSportCenterEventRepository = joinSportCenterEventRepository;
        }

        public JoinEventCreatedBySportCenter AddJoinEvent(JoinEventCreatedBySportCenter joinEvent)
        {
            try
            {
                JoinEventCreatedBySportCenter joinEventReturned = _joinSportCenterEventRepository.GetJoinEventByID(joinEvent.UserId, joinEvent.EventId);
                if (joinEventReturned != null)
                {
                    throw new Exception("This join event already exists!");
                }

                return _joinSportCenterEventRepository.AddJoinEvent(joinEvent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }
        }

        public JoinEventCreatedBySportCenter GetJoinEventByID(int userId, int eventId)
        {
            try
            {
                return _joinSportCenterEventRepository.GetJoinEventByID(userId, eventId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public IEnumerable<JoinEventCreatedBySportCenter> GetJoinEvents()
        {
            try
            {
                return _joinSportCenterEventRepository.GetJoinEvents();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public JoinEventCreatedBySportCenter RemoveJoinEvent(int userId, int eventId)
        {
            try
            {
                JoinEventCreatedBySportCenter joinEvent = _joinSportCenterEventRepository.GetJoinEventByID(userId, eventId);
                if (joinEvent == null)
                {
                    throw new Exception("Join event with this id doesn't exist!");
                }
                return _joinSportCenterEventRepository.RemoveJoinEvent(joinEvent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }
    }
}