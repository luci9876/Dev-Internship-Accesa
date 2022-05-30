using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class EventCreatedBySportCenterService : IEventCreatedBySportCenterService
    {

        private readonly IEventCreatedBySportCenterRepository _eventRepository;

        public EventCreatedBySportCenterService(IEventCreatedBySportCenterRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public EventCreatedBySportCenter AddEvent(EventCreatedBySportCenter Event)
        {
            try
            {
                return _eventRepository.AddEvent(Event);
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding operation failed : {ex.Message}");
            }
        }

        public IEnumerable<EventCreatedBySportCenter> GetEventByAuthor(int authorId)
        {
            try
            {
                return _eventRepository.GetEventByAuthor(authorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public EventCreatedBySportCenter GetEventByID(int id)
        {
            try
            {
                return _eventRepository.GetEventByID(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation by id failed : {ex.Message}");
            }
        }

        public IEnumerable<EventCreatedBySportCenter> GetEvents()
        {
            try
            {
                return _eventRepository.GetEvents();
            }
            catch (Exception ex)
            {
                throw new Exception($"Getting operation failed : {ex.Message}");
            }
        }

        public EventCreatedBySportCenter RemoveEvent(int id)
        {
            try
            {
                var eventReturned = _eventRepository.GetEventByID(id);
                if (eventReturned == null)
                {
                    throw new Exception("Event with this id doesn't exists!");
                }
                return _eventRepository.RemoveEvent(eventReturned);
            }
            catch (Exception ex)
            {
                throw new Exception($"Remove operation failed : {ex.Message}");
            }
        }

        public EventCreatedBySportCenter UpdateEvent(EventCreatedBySportCenter Event)
        {
            try
            {
                var eventToUpdate = _eventRepository.GetEventByID(Event.Id);
                if (eventToUpdate == null)
                {
                    throw new Exception("Event with this id doesn't exists!");
                }

                eventToUpdate.Title = Event.Title;
                eventToUpdate.Description = Event.Description;
                eventToUpdate.AddressId = Event.AddressId;
                eventToUpdate.StartDate = Event.StartDate;
                eventToUpdate.Duration = Event.Duration;
                eventToUpdate.Goal = Event.Goal;
                eventToUpdate.AuthorId = Event.AuthorId;

                return _eventRepository.UpdateEvent(eventToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update operation failed! {ex.Message}");
            }
        }
    }
}