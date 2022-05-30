using Accesa.SportsBuddy.Controllers.Authentication;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Accesa.SportsBuddy.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("administrated-sport-center")]
    public class AdministratedSportCenterController : Controller
    {
        private readonly IAdministratedSportCenterRepository _administratedsportcenterrepository;
        private readonly IMapper _mapper;

        public AdministratedSportCenterController(IAdministratedSportCenterRepository administratedsportcenterrepository, IMapper mapper)
        {
            _administratedsportcenterrepository = administratedsportcenterrepository;
            _mapper = mapper;
        }
        [HttpGet("sport-centers/{adminId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SportCenterDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSportCentersByAdmin(int admin_id)
        {
            try
            {
                var sportCenterDTOs = _mapper.Map<IList<SportCenterDTO>>(_administratedsportcenterrepository.GetSportCentersByAdmin(admin_id));
                return Ok(sportCenterDTOs);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpGet("admins/{sportCenterId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SportCenterAdminAdministratedDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSportCenterAdminsBySportCenter(int sportcenter_id)
        {
            try
            {
                var sportCenterAdminDTOs = _mapper.Map<IList<SportCenterAdminAdministratedDTO>>(_administratedsportcenterrepository.GetSportCentersAdminsBySportCenter(sportcenter_id));
                return Ok(sportCenterAdminDTOs);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpPost("admin-to-sport-center")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddSportCenterAdmintoSportCenter(int sportcenterid, int adminid)
        {
            try
            {
                _administratedsportcenterrepository.AddAdminToSportCenter(sportcenterid, adminid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpDelete("admins/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBySportCenterAdmin(int id)
        {
            try
            {
                _administratedsportcenterrepository.DeleteBySportCenterAdmin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
        [HttpDelete("sport-centers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBySportCenter(int id)
        {
            try
            {
                _administratedsportcenterrepository.DeleteBySportCenter(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
    }
}
