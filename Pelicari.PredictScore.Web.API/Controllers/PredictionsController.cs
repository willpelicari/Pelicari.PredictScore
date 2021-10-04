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
    [Route("prediction")]
    [ApiController]
    public class PredictionsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<PredictionsController> _logger;
        private IService<Prediction> _predictionService;

        public PredictionsController(IService<Prediction> predictionService, IMapper mapper, ILogger<PredictionsController> logger)
        {
            _predictionService = predictionService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PredictionDto>> Get()
        {
            var predictions = _predictionService.GetAll().Select(_mapper.Map<PredictionDto>);
            if (predictions != null)
                return Ok(predictions);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PredictionDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var prediction = await _predictionService.GetAsync(id);
            if (prediction != null)
                return Ok(prediction);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PredictionDto dto)
        {
            var prediction = _mapper.Map<Prediction>(dto);
            await _predictionService.AddAsync(prediction);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PredictionDto dto)
        {
            var prediction = _mapper.Map<Prediction>(dto);
            await _predictionService.UpdateAsync(prediction);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _predictionService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
