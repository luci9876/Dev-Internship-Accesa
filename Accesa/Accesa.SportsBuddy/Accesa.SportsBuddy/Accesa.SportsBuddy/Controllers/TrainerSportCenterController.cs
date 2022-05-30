using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accesa.SportsBuddy.Controllers
{   [Authorize]
    [ApiController]
    [Route("trainer-sport-center")]
    public class TrainerSportCenterController : ControllerBase
    {
        private readonly ITrainerSportCenterService _trainerSportCenterService;
        private readonly IMapper _mapper;
        private readonly ITrainerRepository _trainerRepository;

        public TrainerSportCenterController(ITrainerSportCenterService trainerSportCenterService, IMapper mapper, ITrainerRepository trainerRepository)
        {
            _trainerSportCenterService = trainerSportCenterService;
            _mapper = mapper;
            _trainerRepository = trainerRepository;
        }

        [HttpGet()]
        public IActionResult GetAllTrainerSportCenter()
        {
            try
            {
                var trainerSportCenterRepo = _trainerSportCenterService.GetAllTrainerSportCenter();
                var trainerSportCenterDTOList = _mapper.Map<IList<TrainerSportCenterDTO>>(trainerSportCenterRepo.ToList());
                if (trainerSportCenterDTOList is null)
                {
                    throw new Exception("Unable to fetch list");
                }
                return Ok(trainerSportCenterDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainerSportCenterById(int id)
        {
            try
            {
                var trainerSportCenter = _trainerSportCenterService.GetTrainersBySportCenterId(id);
                var trainerSportCenterDTO = _mapper.Map<TrainerSportCenterDTO>(trainerSportCenter);
                if (trainerSportCenterDTO is null)
                {
                    throw new Exception("Unable to fetch trainerSportCenter");
                }
                return Ok(trainerSportCenterDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost("")]
        public IActionResult AddTrainerSportCenter([FromBody] TrainerSportCenterDTO trainerSportCenterDTOFromBody)
        {
            try
            {
                var trainerSportCenter = _mapper.Map<TrainerSportCenter>(trainerSportCenterDTOFromBody);
                var trainer = _trainerRepository.GetTrainerById(trainerSportCenter.TrainerId);
                var result = _trainerSportCenterService.AddNewTrainerToSportCenter(trainer, trainerSportCenter.SportCenterId);
                var resultDTO = _mapper.Map<TrainerSportCenterDTO>(result);
                if (resultDTO is null)
                {
                    throw new Exception("Unable to add trainerSportCenter");
                }
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}
