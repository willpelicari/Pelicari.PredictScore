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
    [Route("season")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<SeasonsController> _logger;
        private ISeasonService _seasonService;

        public SeasonsController(ISeasonService seasonService, IMapper mapper, ILogger<SeasonsController> logger)
        {
            _seasonService = seasonService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeasonDto>> Get()
        {
            var seasons = _seasonService.GetAll().Select(_mapper.Map<SeasonDto>);
            if (seasons != null)
                return Ok(seasons);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var season = await _seasonService.GetAsync(id);
            if (season != null)
                return Ok(season);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SeasonDto dto)
        {
            var season = _mapper.Map<Season>(dto);
            await _seasonService.AddAsync(season);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SeasonDto dto)
        {
            var season = _mapper.Map<Season>(dto);
            season.Id = id;
            await _seasonService.UpdateAsync(season);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _seasonService.DeleteAsync(id);
            return Ok("Deleted");
        }

        [HttpPost("{seasonId}/group")]
        public async Task<IActionResult> AddGroup(int seasonId, [FromBody] int groupId)
        {
            await _seasonService.AddGroupAsync(seasonId, groupId);
            return Created("localhost", "");
        }
    }
}
