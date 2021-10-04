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
    public class ScoresController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<ScoresController> _logger;
        private IService<Score> _scoreService;

        public ScoresController(IService<Score> scoreService, IMapper mapper, ILogger<ScoresController> logger)
        {
            _scoreService = scoreService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScoreDto>> Get()
        {
            var scores = _scoreService.GetAll().Select(_mapper.Map<ScoreDto>);
            if (scores != null)
                return Ok(scores);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var score = await _scoreService.GetAsync(id);
            if (score != null)
                return Ok(score);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScoreDto dto)
        {
            var score = _mapper.Map<Score>(dto);
            await _scoreService.AddAsync(score);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ScoreDto dto)
        {
            if (id == 0)
                return BadRequest();
            var score = _mapper.Map<Score>(dto);
            score.Id = id;
            await _scoreService.UpdateAsync(score);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _scoreService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
