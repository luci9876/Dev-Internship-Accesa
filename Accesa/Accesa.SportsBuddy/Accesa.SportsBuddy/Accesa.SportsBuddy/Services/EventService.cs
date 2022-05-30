using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event AddEvent(Event Event)
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

        public Event GetEventByID(int id)
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

        public IEnumerable<Event> GetEvents()
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

        public Event RemoveEvent(int id)
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

        public Event UpdateEvent(Event Event)
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

                return _eventRepository.UpdateEvent(eventToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update operation failed! {ex.Message}");
            }
        }

        public IEnumerable<Event> GetEventByAuthor(int authorId)
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
    }
}