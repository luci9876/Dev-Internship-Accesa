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
    [Route("challenge")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService challengeService, IMapper mapper)
        {
            _challengeService = challengeService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetChallenges()
        {
            try
            {
                var challenges = _challengeService.GetChallenges();
                var challengesDTOList = _mapper.Map<IList<ChallengeDTO>>(challenges.ToList());
                if (challengesDTOList == null)
                {
                    throw new Exception("Unable to get all challenges!");
                }
                return Ok(challengesDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer + "," + UserRoles.User)]
        [HttpGet("author/{authorId}")]
        public IActionResult GetChallengeByAuthor(int authorId)
        {
            try
            {
                var challenge = _challengeService.GetChallengeByAuthor(authorId);
                if (challenge == null)
                {
                    throw new Exception("Unable to get challenge!");
                }
                var challengeProgramDTO = _mapper.Map<IList<ChallengeDTO>>(challenge.ToList());

                return Ok(challengeProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetChallengeById(int id)
        {
            try
            {
                Challenge challenge = _challengeService.GetChallengeByID(id);
                var challengeProgramDTO = _mapper.Map<ChallengeDTO>(challenge);
                if (challengeProgramDTO == null)
                {
                    throw new Exception("Unable to get challenge!");
                }
                return Ok(challengeProgramDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer + "," + UserRoles.User)]
        [HttpPost()]
        public IActionResult AddChallenge([FromBody] ChallengeDTO challengeDTO)
        {
            try
            {
                var challenge = _mapper.Map<Challenge>(challengeDTO);
                var resultReturned = _challengeService.AddChallenge(challenge);
                var resultReturnedDTO = _mapper.Map<ChallengeDTO>(resultReturned);
                if (resultReturnedDTO == null)
                {
                    throw new Exception("Unable to add challenge!");
                }
                return Ok(resultReturnedDTO);

            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer + "," + UserRoles.User)]
        [HttpDelete("{id}")]
        public IActionResult RemoveChallenge(int id)
        {
            try
            {
                if (_challengeService.RemoveChallenge(id) == null)
                {
                    throw new Exception("Unable to delete inexistent challenge!");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Trainer + "," + UserRoles.User)]
        [HttpPut()]
        public IActionResult UpdateChallenge([FromBody] ChallengeDTO challengeDTO)
        {
            try
            {
                var challenge = _mapper.Map<Challenge>(challengeDTO);
                var resultReturned = _challengeService.UpdateChallenge(challenge);
                var resultReturnedDTO = _mapper.Map<ChallengeDTO>(resultReturned);
                if (resultReturnedDTO == null)
                {
                    throw new Exception("Unable to update an inexistent challenge!");
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