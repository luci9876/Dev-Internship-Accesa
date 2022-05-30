using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class JoinEventController : ControllerBase
    {
        private readonly IJoinEventService _joinEventService;
        private readonly IMapper _mapper;

        public JoinEventController(IJoinEventService joinEventService, IMapper mapper)
        {
            _joinEventService = joinEventService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetJoinEvents()
        {
            try
            {
                var joinEvents = _joinEventService.GetJoinEvents();
                if (joinEvents == null)
                {
                    throw new Exception("Unable to get all join events!");
                }
                var joinEventsDTOList = _mapper.Map<IList<JoinEventDTO>>(joinEvents.ToList());

                return Ok(joinEventsDTOList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new SportsBuddyErrorResponse
                {
                    ErrorCode = 500,
                    ErrorMessage = $"Internal Error: {ex.Message}",
                    ErrorType = "InternalServerError"
                }
                );
            }
        }

        [HttpGet("{userId}/{eventId}")]
        public IActionResult GetJoinEventById(int userId, int eventId)
        {
            try
            {
                var joinEvent = _joinEventService.GetJoinEventByID(userId, eventId);
                if (joinEvent == null)
                {
                    throw new Exception("Unable to get join event!");
                }
                var joinEventDTO = _mapper.Map<JoinEventDTO>(joinEvent);

                return Ok(joinEventDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new SportsBuddyErrorResponse
                {
                    ErrorCode = 500,
                    ErrorMessage = $"Internal Error: {ex.Message}",
                    ErrorType = "InternalServerError"
                }
                );
            }
        }

        [HttpPost]
        public IActionResult AddJoinEvent([FromBody] JoinEventDTO joinEventDTO)
        {
            try
            {
                var joinEvent = _mapper.Map<JoinEvent>(joinEventDTO);
                var resultReturned = _joinEventService.AddJoinEvent(joinEvent);
                if (resultReturned == null)
                {
                    throw new Exception("Unable to add join event!");
                }
                var resultReturnedDTO = _mapper.Map<JoinEventDTO>(resultReturned);

                return Ok(resultReturnedDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new SportsBuddyErrorResponse
                {
                    ErrorCode = 500,
                    ErrorMessage = $"Internal Error: {ex.Message}",
                    ErrorType = "InternalServerError"
                }
               );
            }
        }

        [HttpDelete("{userId}/{eventId}")]
        public IActionResult RemoveJoinEvent(int userId, int eventId)
        {
            try
            {
                if (_joinEventService.RemoveJoinEvent(userId, eventId) == null)
                {
                    throw new Exception("Unable to delete inexistent join event!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new SportsBuddyErrorResponse
                {
                    ErrorCode = 500,
                    ErrorMessage = $"Internal Error: {ex.Message}",
                    ErrorType = "InternalServerError"
                }
               );
            }
        }
    }
}