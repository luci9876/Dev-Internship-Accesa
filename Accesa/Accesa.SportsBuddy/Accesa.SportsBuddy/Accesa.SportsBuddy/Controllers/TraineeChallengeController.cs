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
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Trainer)]
    [Route("trainee-challenge")]
    [ApiController]
    public class TraineeChallengeController : ControllerBase
    {
        private readonly ITraineeChallengeService _traineeChallengeService;
        private readonly IMapper _mapper;

        public TraineeChallengeController(ITraineeChallengeService traineeChallengeService, IMapper mapper)
        {
            _traineeChallengeService = traineeChallengeService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetTraineeChallenges()
        {
            try
            {
                var traineeChallenges = _traineeChallengeService.GetTraineeChallenges();
                var traineeChallengesDTOList = _mapper.Map<IList<TraineeChallengeDTO>>(traineeChallenges.ToList());
                if (traineeChallengesDTOList == null)
                {
                    throw new Exception("Unable to get all trainee challenges!");
                }
                return Ok(traineeChallengesDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("trainee/{id}")]
        public IActionResult GetTraineeChallengesByTraineeId(int id)
        {
            try
            {
                var traineeChallenges = _traineeChallengeService.GetTraineeChallengesByTraineeId(id);
                var traineeChallengesDTOList = _mapper.Map<IList<TraineeChallengeDTO>>(traineeChallenges.ToList());
                if (traineeChallengesDTOList == null)
                {
                    throw new Exception("Unable to get all trainee challenges!");
                }
                return Ok(traineeChallengesDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{traineeID}/{challengeID}")]
        public IActionResult GetTraineeChallengeById(int traineeID, int challengeID)
        {
            try
            {
                TraineeChallenge traineeChallenge = _traineeChallengeService.GetTraineeChallengeByID(traineeID, challengeID);
                var traineeChallengeProgramDTO = _mapper.Map<TraineeChallengeDTO>(traineeChallenge);
                if (traineeChallengeProgramDTO == null)
                {
                    throw new Exception("Unable to get trainee challenge!");
                }

                return Ok(traineeChallengeProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddTraineeChallenge([FromBody] TraineeChallengeDTO traineeChallengeDTO)
        {
            try
            {
                var traineeChallenge = _mapper.Map<TraineeChallenge>(traineeChallengeDTO);
                var resultReturned = _traineeChallengeService.AddTraineeChallenge(traineeChallenge);
                var resultReturnedDTO = _mapper.Map<TraineeChallengeDTO>(resultReturned);
                if (resultReturnedDTO == null)
                {
                    throw new Exception("Unable to add trainee challenge!");
                }

                return Ok(resultReturnedDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpDelete("{traineeID}/{challengeID}")]
        public IActionResult RemoveTraineeChallenge(int traineeID, int challengeID)
        {
            try
            {
                if (_traineeChallengeService.RemoveTraineeChallenge(traineeID, challengeID) == null)
                {
                    throw new Exception("Unable to delete inexistent trainee challenge!");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateTraineeChallenge([FromBody] TraineeChallengeDTO traineeChallengeDTO)
        {
            try
            {
                var traineeChallenge = _mapper.Map<TraineeChallenge>(traineeChallengeDTO);
                var resultReturned = _traineeChallengeService.UpdateTraineeChallenge(traineeChallenge);
                var resultReturnedDTO = _mapper.Map<TraineeChallengeDTO>(resultReturned);
                if (resultReturnedDTO == null)
                {
                    throw new Exception("Unable to update an inexistent trainee challenge!");
                }

                return Ok(resultReturnedDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}