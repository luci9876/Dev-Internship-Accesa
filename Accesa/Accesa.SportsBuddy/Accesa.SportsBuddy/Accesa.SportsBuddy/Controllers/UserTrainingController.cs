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

namespace Accesa.SportsBuddy.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("user-training")]
    public class UserTrainingController : Controller
    {
        private readonly IUserTrainingService _userTrainingService;
        private readonly IMapper _mapper;
        public UserTrainingController(IUserTrainingService userTrainingService, IMapper mapper)
        {
            _userTrainingService = userTrainingService;
            _mapper = mapper;
        }

        [HttpGet("trainings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TrainingProgramDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllTrainingPrograms()
        {
            try
            {
                var trainingPrograms = _userTrainingService.GetAllTrainingPrograms();
                var trainingProgramDTO = _mapper.Map<IList<TrainingProgramDTO>>(trainingPrograms.ToList());
                if (trainingProgramDTO is null)
                {
                    throw new Exception("Unable to fetch all training programs");
                }
                return Ok(trainingProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainingProgramDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrainingProgramById(int id)
        {
            try
            {
                var trainingProgram = _userTrainingService.GetTrainingProgramById(id);
                var trainingProgramDTO = _mapper.Map<TrainingProgramDTO>(trainingProgram);
                if (trainingProgramDTO is null)
                {
                    throw new Exception("Unable to fetch training programs");
                }
                return Ok(trainingProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTrainingProgram([FromBody] TrainingProgram trainingProgramDTOFromBody)
        {
            try
            {
                var trainingProgram = _mapper.Map<TrainingProgram>(trainingProgramDTOFromBody);
                var result = _userTrainingService.UpdateTrainingProgram(trainingProgram);
                var resultDTO = _mapper.Map<TrainingProgramDTO>(result);
                if (resultDTO is null)
                {
                    throw new Exception("Unable to update training program");
                }
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTrainingProgram([FromBody] TrainingProgramDTO trainingProgram)
        {
            try
            {
                _userTrainingService.AddTrainingProgram(trainingProgram);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTrainingProgram([FromForm] int id)
        {
            if (id == 0)
            {
                return NotFound(new SportsBuddyErrorResponse
                {
                    ErrorCode = 404,
                    ErrorMessage = $"Couldn't find training program with id {id}",
                    ErrorType = "NotFoundException"
                }
                );
            }
            try
            {
                _userTrainingService.DeleteTrainingProgram(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}
