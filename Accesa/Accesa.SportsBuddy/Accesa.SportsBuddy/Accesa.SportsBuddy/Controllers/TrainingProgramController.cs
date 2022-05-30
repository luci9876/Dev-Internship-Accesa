using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.Controllers.Models;
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
    [Route("training-program")]
    [ApiController]
    public class TrainingProgramController : ControllerBase
    {
        private readonly ITrainingProgramService _trainingProgramService;
        private readonly IMapper _mapper;

        public TrainingProgramController(ITrainingProgramService trainingProgramService, IMapper mapper)
        {
            _trainingProgramService = trainingProgramService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetAllTrainingPrograms()
        {
            try
            {
                var trainingPrograms = _trainingProgramService.GetAllTrainingPrograms();
                var trainingProgramDTOList = _mapper.Map<IList<TrainingProgramDTO>>(trainingPrograms.ToList());
                if (trainingProgramDTOList == null)
                {
                    throw new Exception("Unable to get all training programs!");
                }
                return Ok(trainingProgramDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingProgramById(int id)
        {
            try
            {
                TrainingProgram trainingProgram = _trainingProgramService.GetTrainingProgramById(id);
                var trainingProgramDTO = _mapper.Map<TrainingProgramDTO>(trainingProgram);
                if (trainingProgramDTO == null)
                {
                    throw new Exception("Unable to get training program!");
                }
                return Ok(trainingProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer)]
        [HttpPost()]
        public IActionResult AddTrainingProgram([FromBody] TrainingProgramDTO trainingProgramDTO)
        {
            try
            {
                var trainingProgram = _mapper.Map<TrainingProgram>(trainingProgramDTO);
                var resultReturned = _trainingProgramService.AddTrainingProgram(trainingProgram);
                var resultReturnedDTO = _mapper.Map<TrainingProgramDTO>(resultReturned);
                if (resultReturnedDTO == null)
                {
                    throw new Exception("Unable to add training program!");
                }
                return Ok(resultReturnedDTO);

            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer)]
        [HttpDelete("{id}")]
        public IActionResult RemoveTrainingProgram(int id)
        {
            try
            {
                if (_trainingProgramService.RemoveTrainingProgram(id) == null)
                {
                    throw new Exception("Unable to delete inexistent training program!");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer)]
        [HttpPut()]
        public IActionResult UpdateTrainingProgram([FromBody] ActivityTrainerTrainingProgramInfo activityTrainerTrainingProgramInfo)
        {
            try
            {
                var steps = string.Empty;
                foreach (var step in activityTrainerTrainingProgramInfo.TrainingProgramRecommendedSteps)
                {
                    if (string.IsNullOrWhiteSpace(steps))
                        steps += step;
                    else
                        steps += ";" + step;
                }

                var trainingProgram = new TrainingProgram
                {
                    Id = activityTrainerTrainingProgramInfo.TrainingProgramId,
                    Name = activityTrainerTrainingProgramInfo.TrainingProgramName,
                    Difficulty = activityTrainerTrainingProgramInfo.TrainingProgramDifficulty,
                    Description = activityTrainerTrainingProgramInfo.TrainingProgramDescription,
                    Duration = activityTrainerTrainingProgramInfo.TrainingProgramDuration,
                    Location = activityTrainerTrainingProgramInfo.TrainingProgramLocation,
                    RecommendedSteps = steps,
                    Rating = activityTrainerTrainingProgramInfo.TrainingProgramRating
                };

                if (activityTrainerTrainingProgramInfo.TrainingProgramSportCenter.Id > 0)
                {
                    trainingProgram.SportCenterId = activityTrainerTrainingProgramInfo.TrainingProgramSportCenter.Id;
                }

                _trainingProgramService.UpdateTrainingProgram(trainingProgram);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}