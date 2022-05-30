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
{   //[Authorize]
    [ApiController]
    [Route("sport-center")]
    public class SportCenterController : Controller
    {
        private readonly ISportCenterRepository _sportCenterRepository;
        private readonly IMapper _mapper;

        public SportCenterController(ISportCenterRepository sportCenterRepository, IMapper mapper)
        {
            _sportCenterRepository = sportCenterRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SportCenterDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSportCenterById(int id)
        {
            try
            {
                var sportcenter = _sportCenterRepository.GetSportCenterById(id);
                if (sportcenter == null) return NotFound(); ;
                var sportCenterDTO = _mapper.Map<SportCenterDTO>(sportcenter);
                return Ok(sportCenterDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSportCenterById(int id)
        {
            try
            {
                _sportCenterRepository.DeleteSportCenterById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SportCenterDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddSportCenter([FromBody] SportCenterDTO sportcenterdto)
        {
            try
            {
                var result = _sportCenterRepository.CreateSportCenter(sportcenterdto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateSportCenter(int id, [FromBody] SportCenterDTO sportcenterdto)
        {
            try
            {
                _sportCenterRepository.EditSportCenter(id, sportcenterdto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SportCenterDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllSportCenters()
        {
            try
            {
                var sportcenters = _sportCenterRepository.GetAllSportCenters();
                var sportcentersDTO = _mapper.Map<IList<SportCenterDTO>>(sportcenters);
                return Ok(sportcentersDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }
    }
}
