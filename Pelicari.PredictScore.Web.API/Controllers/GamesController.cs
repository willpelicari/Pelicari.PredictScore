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
    public class GamesController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<GamesController> _logger;
        private IService<Game> _gameService;

        public GamesController(IService<Game> gameService, IMapper mapper, ILogger<GamesController> logger)
        {
            _gameService = gameService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> Get()
        {
            var games = _gameService.GetAll().Select(_mapper.Map<GameDto>);
            if (games != null)
                return Ok(games);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var game = await _gameService.GetAsync(id);
            if (game != null)
                return Ok(game);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _gameService.AddAsync(game);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GameDto dto)
        {
            if (id == 0)
                return BadRequest();
            var game = _mapper.Map<Game>(dto);
            game.Id = id;
            await _gameService.UpdateAsync(game);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _gameService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
