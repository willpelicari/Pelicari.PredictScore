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
    public class SportsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<SportsController> _logger;
        private IService<Sport> _sportService;

        public SportsController(IService<Sport> sportService, IMapper mapper, ILogger<SportsController> logger)
        {
            _sportService = sportService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SportDto>> Get()
        {
            var sports = _sportService.GetAll().Select(_mapper.Map<SportDto>);
            if (sports != null)
                return Ok(sports);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SportDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var sport = await _sportService.GetAsync(id);
            if (sport != null)
                return Ok(sport);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SportDto dto)
        {
            var sport = _mapper.Map<Sport>(dto);
            await _sportService.AddAsync(sport);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SportDto dto)
        {
            if (id == 0)
                return BadRequest();
            var sport = _mapper.Map<Sport>(dto);
            sport.Id = id;
            await _sportService.UpdateAsync(sport);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _sportService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
