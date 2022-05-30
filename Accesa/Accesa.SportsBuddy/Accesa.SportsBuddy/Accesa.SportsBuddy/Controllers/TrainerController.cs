using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accesa.SportsBuddy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("trainer")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly ITraineeService _traineeService;
        private readonly IMapper _mapper;

        public TrainerController(ITrainerService trainerService, IMapper mapper, ITraineeService traineeService)
        {
            _trainerService = trainerService;
            _traineeService = traineeService;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TrainerInfo>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllTrainers()
        {
            try
            {
                var trainerRepo = _trainerService.GetAllTrainers();
                if (trainerRepo is null)
                {
                    throw new Exception("No records");
                }

                var trainerDTOList = _mapper.Map<IList<TrainerDTO>>(trainerRepo.ToList());
                var trainers = new List<TrainerInfo>();
                foreach (var trainerDTO in trainerDTOList)
                {
                    var trainer = _mapper.Map<TrainerInfo>(trainerDTO);
                    trainers.Add(trainer);
                }

                return Ok(trainers);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainerInfo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrainerById(int id)
        {
            try
            {
                var trainer = _trainerService.GetTrainerById(id);
                var trainerInfo = _mapper.Map<TrainerInfo>(trainer);
                return Ok(trainerInfo);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTrainer([FromBody] TrainerInfo trainerFromBody)
        {
            try
            {
                var trainer = _mapper.Map<Trainer>(trainerFromBody);
                trainer.Id = 0;
                var result = _trainerService.AddTrainer(trainer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }

        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTrainer([FromBody] TrainerInfo trainerFromBody)
        {
            try
            {
                #region "Address declaration"
                var address = new Address
                {
                    Id = trainerFromBody.AddressNavigation.Id,
                    City = trainerFromBody.AddressNavigation.City,
                    Street = trainerFromBody.AddressNavigation.Street,
                    State = trainerFromBody.AddressNavigation.State,
                    PostalCode = trainerFromBody.AddressNavigation.PostalCode,
                    Country = trainerFromBody.AddressNavigation.Country,
                    Latitude = trainerFromBody.AddressNavigation.Latitude,
                    Longitude = trainerFromBody.AddressNavigation.Longitude
                };
                #endregion

                var user = _mapper.Map<User>(trainerFromBody);
                _traineeService.UpdateTrainee(user);

                var trainer = new Trainer
                {
                    Id = trainerFromBody.TrainerId,
                    Rating = trainerFromBody.Rating,
                    IsAvailable = trainerFromBody.IsAvailable
                };

                var result = _trainerService.UpdateTrainer(trainer);
                if (result is null)
                {
                    throw new Exception("Unable to fetch result");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTrainer(int id)
        {
            
            try
            {
                _trainerService.DeleteTrainer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
    }
}
