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
    [ApiController]
    [Route("trainer-training-program")]
    public class TrainerTrainingProgramController : Controller
    {
        private readonly ITrainerTrainingProgramService _trainerTrainingProgramService;
        private readonly ITrainingProgramService _trainingProgramService;
        private readonly IMapper _mapper;

        public TrainerTrainingProgramController(ITrainerTrainingProgramService trainerTrainingProgramService, ITrainingProgramService trainingProgramService, IMapper mapper)
        {
            _trainerTrainingProgramService = trainerTrainingProgramService;
            _trainingProgramService = trainingProgramService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ActivityTrainerTrainingProgramInfo>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrainingsInfo()
        {
            try
            {
                var trainerTrainingPrograms = _trainerTrainingProgramService.GetTrainingsInfo();
                if (trainerTrainingPrograms is null)
                {
                    throw new Exception("No records found!");
                }

                var trainerTrainingProgramDTOList = _mapper.Map<IList<TrainerTrainingProgramDTO>>(trainerTrainingPrograms.ToList());
                if (trainerTrainingProgramDTOList is null)
                {
                    throw new Exception("Unable to fetch all records!");
                }

                var activityTrainerTrainingProgramInfo = new List<ActivityTrainerTrainingProgramInfo>();
                foreach (TrainerTrainingProgramDTO trainerTrainingProgramDTO in trainerTrainingProgramDTOList)
                {
                    activityTrainerTrainingProgramInfo.Add(new ActivityTrainerTrainingProgramInfo
                    {
                        TrainingProgramId = trainerTrainingProgramDTO.TrainingProgramId,
                        TrainingProgramName = trainerTrainingProgramDTO.TrainingProgramName,
                        TrainingProgramDifficulty = trainerTrainingProgramDTO.TrainingProgramDifficulty,
                        TrainingProgramDescription = trainerTrainingProgramDTO.TrainingProgramDescription,
                        TrainingProgramRecommendedSteps = trainerTrainingProgramDTO.TrainingProgramRecommendedSteps.Split(';'),
                        TrainingProgramDuration = trainerTrainingProgramDTO.TrainingProgramDuration,
                        TrainingProgramLocation = trainerTrainingProgramDTO.TrainingProgramLocation,
                        TrainingProgramSportCenter = trainerTrainingProgramDTO.TrainingProgramSportCenter,
                        Trainer = trainerTrainingProgramDTO.Trainer,
                        TrainingProgramRating = trainerTrainingProgramDTO.TrainingProgramRating
                    });
                }

                return Ok(activityTrainerTrainingProgramInfo);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("trainer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ActivityTrainerTrainingProgramInfo>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrainingsInfoByTrainerId(int id)
        {
            try
            {
                var trainerTrainingPrograms = _trainerTrainingProgramService.GetTrainingsInfoByTrainerId(id);
                if (trainerTrainingPrograms is null)
                {
                    throw new Exception("No records found!");
                }

                var trainerTrainingProgramDTOList = _mapper.Map<IList<TrainerTrainingProgramDTO>>(trainerTrainingPrograms.ToList());
                var activityTrainerTrainingProgramInfo = new List<ActivityTrainerTrainingProgramInfo>();
                foreach (var trainerTrainingProgramDTO in trainerTrainingProgramDTOList)
                {
                    activityTrainerTrainingProgramInfo.Add(new ActivityTrainerTrainingProgramInfo
                    {
                        TrainingProgramId = trainerTrainingProgramDTO.TrainingProgramId,
                        TrainingProgramName = trainerTrainingProgramDTO.TrainingProgramName,
                        TrainingProgramDifficulty = trainerTrainingProgramDTO.TrainingProgramDifficulty,
                        TrainingProgramDescription = trainerTrainingProgramDTO.TrainingProgramDescription,
                        TrainingProgramRecommendedSteps = trainerTrainingProgramDTO.TrainingProgramRecommendedSteps.Split(';'),
                        TrainingProgramDuration = trainerTrainingProgramDTO.TrainingProgramDuration,
                        TrainingProgramLocation = trainerTrainingProgramDTO.TrainingProgramLocation,
                        TrainingProgramSportCenter = trainerTrainingProgramDTO.TrainingProgramSportCenter,
                        Trainer = trainerTrainingProgramDTO.Trainer,
                        TrainingProgramRating = trainerTrainingProgramDTO.TrainingProgramRating
                    });
                }

                return Ok(activityTrainerTrainingProgramInfo);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActivityTrainerTrainingProgramInfo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrainingInfoById(int id)
        {
            try
            {
                var trainerTrainingProgram = _trainerTrainingProgramService.GetTrainingInfoById(id);
                if (trainerTrainingProgram is null)
                {
                    throw new Exception("No records found!");
                }

                var trainerTrainingProgramDTO = _mapper.Map<TrainerTrainingProgramDTO>(trainerTrainingProgram);
                if (trainerTrainingProgramDTO is null)
                {
                    throw new Exception("Unable to fetch all records!");
                }

                var result = new ActivityTrainerTrainingProgramInfo
                {
                    TrainingProgramId = trainerTrainingProgramDTO.TrainingProgramId,
                    TrainingProgramName = trainerTrainingProgramDTO.TrainingProgramName,
                    TrainingProgramDifficulty = trainerTrainingProgramDTO.TrainingProgramDifficulty,
                    TrainingProgramDescription = trainerTrainingProgramDTO.TrainingProgramDescription,
                    TrainingProgramRecommendedSteps = trainerTrainingProgramDTO.TrainingProgramRecommendedSteps.Split(';'),
                    TrainingProgramDuration = trainerTrainingProgramDTO.TrainingProgramDuration,
                    TrainingProgramLocation = trainerTrainingProgramDTO.TrainingProgramLocation,
                    TrainingProgramSportCenter = trainerTrainingProgramDTO.TrainingProgramSportCenter,
                    Trainer = trainerTrainingProgramDTO.Trainer,
                    TrainingProgramRating = trainerTrainingProgramDTO.TrainingProgramRating
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTrainerTrainingProgram([FromBody] ActivityTrainerTrainingProgramInfo activityTrainerTrainingProgramInfo)
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

                var trainingProgram = _trainingProgramService.AddTrainingProgram(new TrainingProgram
                {
                    Name = activityTrainerTrainingProgramInfo.TrainingProgramName,
                    Difficulty = activityTrainerTrainingProgramInfo.TrainingProgramDifficulty,
                    Description = activityTrainerTrainingProgramInfo.TrainingProgramDescription,
                    Duration = activityTrainerTrainingProgramInfo.TrainingProgramDuration,
                    Location = activityTrainerTrainingProgramInfo.TrainingProgramLocation,
                    RecommendedSteps = steps,
                    SportCenterId = activityTrainerTrainingProgramInfo.TrainingProgramSportCenter.Id
                });

                _trainerTrainingProgramService.AddTrainerTrainingProgram(new TrainerTrainingProgram
                {
                    TrainerId = activityTrainerTrainingProgramInfo.Trainer.Id,
                    TrainingProgramId = trainingProgram.Id
                });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}