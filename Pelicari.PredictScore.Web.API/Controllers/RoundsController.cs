using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Web.API.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Web.API.Controllers
{
    [Route("schedule/{scheduleId}/round")]
    [ApiController]
    public class RoundsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<RoundsController> _logger;
        private IService<Round> _roundService;

        public RoundsController(IService<Round> roundService, IMapper mapper, ILogger<RoundsController> logger)
        {
            _roundService = roundService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoundDto>> Get()
        {
            var rounds = _roundService.GetAll().Select(_mapper.Map<RoundDto>);
            if (rounds != null)
                return Ok(rounds);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoundDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var round = await _roundService.GetAsync(id);
            if (round != null)
                return Ok(round);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(int scheduleId, [FromBody] RoundDto dto)
        {
            var round = _mapper.Map<Round>(dto);
            round.ScheduleId = scheduleId;
            await _roundService.AddAsync(round);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoundDto dto)
        {
            if (id == 0)
                return BadRequest();
            var round = _mapper.Map<Round>(dto);
            round.Id = id;
            await _roundService.UpdateAsync(round);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _roundService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
