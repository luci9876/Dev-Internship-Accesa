using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accesa.SportsBuddy.Controllers
{
    [Route("event-sport-center")]
    [ApiController]
    public class EventCreatedBySportCenterController : ControllerBase
    {
        private readonly IEventCreatedBySportCenterService _eventService;
        private readonly IMapper _mapper;

        public EventCreatedBySportCenterController(IEventCreatedBySportCenterService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                var events = _eventService.GetEvents();
                if (events == null)
                {
                    throw new Exception("Unable to get all events!");
                }
                var eventsDTOList = _mapper.Map<IList<EventCreatedBySportCenterDTO>>(events.ToList());

                return Ok(eventsDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                var returnedEvent = _eventService.GetEventByID(id);
                if (returnedEvent == null)
                {
                    throw new Exception("Unable to get event!");
                }
                var returnedEventDTO = _mapper.Map<EventCreatedBySportCenterDTO>(returnedEvent);

                return Ok(returnedEventDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddEvent([FromBody] EventCreatedBySportCenterDTO eventDTO)
        {
            try
            {
                var receivedEvent = _mapper.Map<EventCreatedBySportCenter>(eventDTO);
                var resultReturned = _eventService.AddEvent(receivedEvent);
                if (resultReturned == null)
                {
                    throw new Exception("Unable to add event!");
                }
                var resultReturnedDTO = _mapper.Map<EventCreatedBySportCenterDTO>(resultReturned);

                return Ok(resultReturnedDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public IActionResult RemoveEvent(int id)
        {
            try
            {
                if (_eventService.RemoveEvent(id) == null)
                {
                    throw new Exception("Unable to delete inexistent event!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public IActionResult UpdateEvent([FromBody] EventCreatedBySportCenterDTO eventDTO)
        {
            try
            {
                var receivedEvent = _mapper.Map<EventCreatedBySportCenter>(eventDTO);
                var resultReturned = _eventService.UpdateEvent(receivedEvent);
                if (resultReturned == null)
                {
                    throw new Exception("Unable to update an inexistent event!");
                }
                var resultReturnedDTO = _mapper.Map<EventCreatedBySportCenterDTO>(resultReturned);

                return Ok(resultReturnedDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("event/{authorId}")]
        public IActionResult GetEventByAuthor(int authorId)
        {
            try
            {
                var events = _eventService.GetEventByAuthor(authorId);
                if (events == null)
                {
                    throw new Exception("Unable to get event!");
                }
                var eventsDTO = _mapper.Map<IList<EventCreatedBySportCenterDTO>>(events.ToList());

                return Ok(eventsDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

    }
}