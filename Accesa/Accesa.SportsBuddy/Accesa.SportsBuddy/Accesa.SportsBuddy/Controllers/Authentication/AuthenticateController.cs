using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.Repositories.Interfaces;

namespace JWTAuthentication.Controllers
{
    [Route("authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITraineeService _traineeService;
        private readonly ISportCenterAdminService _sportCenterAdminService;
        private readonly ITrainerService _trainerService;
        private readonly IMapper _mapper;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITraineeService traineeService, ISportCenterAdminService sportCenterAdminService, ITrainerService trainerService, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _traineeService = traineeService;
            _trainerService = trainerService;
            _sportCenterAdminService = sportCenterAdminService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                try
                {
                    var trainerReturn = _trainerService.GetTrainerByEmail(model.Email);
                    if (trainerReturn != null)
                    {
                        //var trainerReturnDTO = _mapper.Map<TrainerDTO>(trainerReturn);
                        var trainerInfo = _mapper.Map<TrainerInfo>(trainerReturn);
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            user = trainerInfo
                        });
                    }
                }
                catch
                {

                }

                try
                {
                    var userReturn = _traineeService.GetUserByEmail(model.Email);
                    if (userReturn != null)
                    {
                        var userReturnDTO = _mapper.Map<TraineeDTO>(userReturn);
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            user = userReturnDTO
                        });
                    }
                }
                catch
                {
                    
                }

                try
                {
                    var adminReturn = _sportCenterAdminService.GetSportCenterAdminByEmail(model.Email);

                    if (adminReturn != null)
                    {
                        var adminReturnDTO = _mapper.Map<SportCenterAdminDTO>(adminReturn);
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            user = adminReturnDTO
                        });
                    }
                }
                catch
                {

                }

                
            }
            return Unauthorized("Unauthorized");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email
                };

                var traineeDTO = new TraineeDTO()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = "F",
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    BirthDate = model.BirthDate,
                    role = new RoleDTO()
                    {
                        Id = 1,
                        Name = "Trainee"
                    },
                    addressNavigation = new AddressDTO()
                    {
                        State = string.Empty,
                        Street = string.Empty,
                        City = string.Empty,
                        Country = string.Empty,
                        PostalCode = string.Empty,
                    }

                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                else
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    if (await roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await userManager.AddToRoleAsync(user, UserRoles.User);
                    }
                    var trainee = _mapper.Map<User>(traineeDTO);
                    if (trainee is null)
                    {
                        throw new Exception("The record doesn't exist");
                    }

                    var resultUser = _traineeService.AddTrainee(trainee);
                    if (resultUser is null)
                    {
                        throw new Exception("Unable to add trainee");
                    }
                }
                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email
                };

                var sportCenterAdminDTO = new SportCenterAdminDTO()
                {
                    Name = model.FirstName,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    Birthdate = model.BirthDate,
                    Role = new RoleDTO()
                    {
                        Id = 3,
                        Name = "Admin"
                    }

                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                var admin = _mapper.Map<SportCenterAdmin>(sportCenterAdminDTO);
                if (admin is null)
                {
                    throw new Exception("Admin is null");
                }

                var resultSportCenterAdmin = _sportCenterAdminService.AddNewSportCenterAdmin(admin);
                if (resultSportCenterAdmin is null)
                {
                    throw new Exception("Unable to add admin to repo");
                }

                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}