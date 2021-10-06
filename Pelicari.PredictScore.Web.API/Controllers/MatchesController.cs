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
    [Route("[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<MatchesController> _logger;
        private IService<Match> _matchService;

        public MatchesController(IService<Match> matchService, IMapper mapper, ILogger<MatchesController> logger)
        {
            _matchService = matchService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MatchDetailDto>> Get()
        {
            var matches = _matchService.GetAll().Select(_mapper.Map<MatchDetailDto>);
            if (matches != null)
                return Ok(matches);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDetailDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var match = await _matchService.GetAsync(id);
            if (match != null)
                return Ok(match);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MatchDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            await _matchService.AddAsync(match);
            return Created("localhost", "");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _matchService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
