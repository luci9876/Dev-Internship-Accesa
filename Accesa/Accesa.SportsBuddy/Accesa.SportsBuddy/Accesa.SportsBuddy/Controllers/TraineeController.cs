using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Accesa.SportsBuddy.Controllers.Authentication.UserRoles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accesa.SportsBuddy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("trainee")]
    public class TraineeController : ControllerBase
    {
        private readonly ITraineeService _traineeService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TraineeController(ITraineeService traineeService, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _traineeService = traineeService;
            _mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllTrainees()
        {
            try
            {
                var traineeRepo = _traineeService.GetAllTrainees();
                if (traineeRepo is null)
                {
                    throw new Exception("No trainees");
                }
                var traineeDTOList = _mapper.Map<IList<TraineeDTO>>(traineeRepo.ToList());
                if (traineeDTOList is null)
                {
                    throw new Exception("Unable to fetch all trainees");
                }
                return Ok(traineeDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("trainees/score")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllTraineesSortedByScore()
        {
            try
            {
                var traineeRepo = _traineeService.GetAllTraineesSortedByScore();
                if (traineeRepo is null)
                {
                    throw new Exception("No sorted trainees");
                }

                var traineeDTOList = _mapper.Map<IList<TraineeDTO>>(traineeRepo.ToList());

                return Ok(traineeDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTraineeById(int id)
        {
            try
            {
                var trainee = _traineeService.GetTraineeById(id);
                if (trainee is null)
                {
                    throw new Exception("The record doesn't exist");
                }
                var traineeDTO = _mapper.Map<TraineeDTO>(trainee);
                if (traineeDTO is null)
                {
                    throw new Exception("Unable to fetch trainee");
                }
                return Ok(traineeDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTrainee([FromBody] TraineeDTO traineeDTOFromBody)
        {
            try
            {
                var existingTrainee = _traineeService.GetTraineeById(traineeDTOFromBody.Id);
                var trainee = _mapper.Map<User>(traineeDTOFromBody);
                var result = _traineeService.UpdateTrainee(trainee);
                if (result is null)
                {
                    throw new Exception("Unable to update trainee");
                }
                
                var aspUser = userManager.FindByEmailAsync(trainee.Email);
                if (GetDirection(existingTrainee, trainee).Equals(RoleDirection.UserToTrainer))
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.Trainer))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Trainer));

                    if (await roleManager.RoleExistsAsync(UserRoles.Trainer))
                        {
                            await userManager.RemoveFromRoleAsync(aspUser.Result, UserRoles.User);
                            await userManager.AddToRoleAsync(aspUser.Result, UserRoles.Trainer);
                        }
                    
                }
                else if(GetDirection(existingTrainee, trainee).Equals(RoleDirection.TrainerToUser))
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    if (await roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await userManager.RemoveFromRoleAsync(aspUser.Result, UserRoles.Trainer);
                        await userManager.AddToRoleAsync(aspUser.Result, UserRoles.User);
                    }
                }

                var resultDTO = _mapper.Map<TraineeDTO>(result);

                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }

        }

        [AllowAnonymous]
        [HttpPut("trainee-score/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTraineeScore(int id)
        {
            if (id == 0)
            {
                return NotFound("The record doesn't exist");
            }
            try
            {
                var result = _traineeService.UpdateUserScore(id);
                if (result is null)
                {
                    throw new Exception("Unable to update trainee's score");
                }
                var resultDTO = _mapper.Map<TraineeDTO>(result);

                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTrainee([FromBody] TraineeDTO traineeDTOFromBody)
        {
            try
            {
                var trainee = _mapper.Map<User>(traineeDTOFromBody);
                if (trainee is null)
                {
                    throw new Exception("Trainee is null");
                }
                var result = _traineeService.AddTrainee(trainee);
                if (result is null)
                {
                    throw new Exception("Unable to add trainee to repo");
                }
                var resultDTO = _mapper.Map<TraineeDTO>(result);
                if (resultDTO is null)
                {
                    throw new Exception("Unable to add trainee");
                }
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTrainee(int id)
        {
            if (id == 0)
            {
                return NotFound("Th record doesn't exist");
            }
            try
            {
                _traineeService.DeleteTrainee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult HasValidCredentials([FromBody] UserCredentials info)
        {
            try
            {
                if (_traineeService.HasValidCredentials(info))
                    return Ok();
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        private RoleDirection GetDirection(User currentUser, User updatedUser)
        {
            if (currentUser.Role.Id == updatedUser.Role.Id)
                return RoleDirection.NoUpdate;
            if (currentUser.Role.Id > updatedUser.Role.Id)
                return RoleDirection.TrainerToUser;
            if (currentUser.Role.Id < updatedUser.Role.Id)
                return RoleDirection.UserToTrainer;
            return RoleDirection.NoUpdate;
        }
    }
}
