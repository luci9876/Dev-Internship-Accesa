using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class JoinEventService : IJoinEventService
    {

        private readonly IJoinEventRepository _joinEventRepository;
        public JoinEventService(IJoinEventRepository joinEventRepository)
        {
            _joinEventRepository = joinEventRepository;
        }

        public JoinEvent AddJoinEvent(JoinEvent joinEvent)
        {
            try
            {
                JoinEvent joinEventReturned = _joinEventRepository.GetJoinEventByID(joinEvent.UserId, joinEvent.EventId);
                if (joinEventReturned != null)
                {
                    throw new Exception("This join event already exists!");
                }

                return _joinEventRepository.AddJoinEvent(joinEvent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }
        }

        public JoinEvent GetJoinEventByID(int userId, int eventId)
        {
            try
            {
                return _joinEventRepository.GetJoinEventByID(userId, eventId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public IEnumerable<JoinEvent> GetJoinEvents()
        {
            try
            {
                return _joinEventRepository.GetJoinEvents();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public JoinEvent RemoveJoinEvent(int userId, int eventId)
        {
            try
            {
                JoinEvent joinEvent = _joinEventRepository.GetJoinEventByID(userId, eventId);
                if (joinEvent == null)
                {
                    throw new Exception("Join event with this id doesn't exist!");
                }
                return _joinEventRepository.RemoveJoinEvent(joinEvent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }
    }
}