using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pelicari.PredictScore.Core.Services;
using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Web.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<TeamsController> _logger;
        private IService<Team> _teamService;

        public TeamsController(IService<Team> teamService, IMapper mapper, ILogger<TeamsController> logger)
        {
            _teamService = teamService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamDto>> Get([FromRoute] int teamId)
        {
            if (teamId == 0)
                return BadRequest();
            var team = await _teamService.GetAsync(teamId);
            if(team != null)
                return Ok(team);
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> GetAll()
        {
            var team = _teamService.GetAll();
            if (team != null)
                return Ok(team);
            return NotFound();
        }

        [HttpPut("{teamId}")]
        public async Task<IActionResult> Put(int teamId, TeamDto dto)
        {
            if (teamId == 0)
                return BadRequest();
            var team = _mapper.Map<Team>(dto);
            team.Id = teamId;
            await _teamService.UpdateAsync(team);
            return Ok("Updated");
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeamDto dto)
        {
            var team = _mapper.Map<Team>(dto);
            await _teamService.AddAsync(team);
            return Created("localhost","");
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> Delete([FromRoute] int teamId)
        {
            if (teamId == 0)    
                return BadRequest();
            await _teamService.DeleteAsync(teamId);
            return Ok("Deleted");
        }
    }
}
