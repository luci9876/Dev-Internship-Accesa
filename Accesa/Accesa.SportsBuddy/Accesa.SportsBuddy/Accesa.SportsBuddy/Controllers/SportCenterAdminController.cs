using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services;
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
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("sport-center-admin")]
    public class SportCenterAdminController : Controller
    {
        //private readonly ISportCenterAdminRepository _sportCenterAdminRepository;
        private readonly ISportCenterAdminService _sportCenterAdminService;
        private readonly IMapper _mapper;

        public SportCenterAdminController(ISportCenterAdminService sportCenterAdminService, IMapper mapper)
        {
            _sportCenterAdminService = sportCenterAdminService;
            _mapper = mapper;
        }
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SportCenterAdminDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllSportCenterAdmins()
        {
            try
            {
                var adminsRepo = _sportCenterAdminService.GetAllSportCenterAdmins();
                if (adminsRepo is null)
                {
                    throw new Exception("No admins");
                }
                var adminDTOList = _mapper.Map<IList<SportCenterAdminDTO>>(adminsRepo.ToList());
                if (adminDTOList is null)
                {
                    throw new Exception("Unable to fetch all admins");
                }
                return Ok(adminDTOList);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SportCenterAdminDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSportCenterAdminById(int id)
        {
            try
            {
                var admin = _sportCenterAdminService.GetSportCenterAdminById(id);
                if (admin is null)
                {
                    throw new Exception("The record doesn't exist");
                }
                var adminDTO = _mapper.Map<SportCenterAdminDTO>(admin);
                if (adminDTO is null)
                {
                    throw new Exception("Unable to fetch admin");
                }
                return Ok(adminDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditSportCenterAdmin([FromBody] SportCenterAdminDTO sportCenterAdminDTO)
        {
            try
            {
                var sportCenterAdmin = _mapper.Map<SportCenterAdmin>(sportCenterAdminDTO);
                if (sportCenterAdmin is null)
                {
                    throw new Exception("The record doesn't exist");
                }
                var result = _sportCenterAdminService.EditSportCenterAdmin(sportCenterAdmin);
                if (result is null)
                {
                    throw new Exception("Unable to update admin");
                }
                var resultDTO = _mapper.Map<SportCenterAdminDTO>(result);
                if (resultDTO is null)
                {
                    throw new Exception("Unable to update admin");
                }
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNewSportCenterAdmin([FromBody] SportCenterAdminDTO sportCenterAdmin)
        {
            try
            {
                var admin = _mapper.Map<SportCenterAdmin>(sportCenterAdmin);
                if (admin is null)
                {
                    throw new Exception("Admin is null");
                }
                var result = _sportCenterAdminService.AddNewSportCenterAdmin(admin);
                if (result is null)
                {
                    throw new Exception("Unable to add admin to repo");
                }
                var resultDTO = _mapper.Map<SportCenterAdminDTO>(result);
                if (resultDTO is null)
                {
                    throw new Exception("Unable to add admin");
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
        public IActionResult LoginAsSportCenterAdmin([FromBody] AdminLoginInfo adminLoginInfo)
        {
            try
            {
                bool canLoginIn = _sportCenterAdminService.LoginAsSportCenterAdmin(adminLoginInfo);
                if (canLoginIn)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSportCenterAdmin([FromForm] int id)
        {
            if (id == 0)
            {
                return NotFound("Th record doesn't exist");
            }
            try
            {
                _sportCenterAdminService.DeleteSportCenterAdmin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
    }
}
