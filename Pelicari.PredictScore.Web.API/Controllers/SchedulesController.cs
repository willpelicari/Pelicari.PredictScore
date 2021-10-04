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
    [Route("schedule")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<SchedulesController> _logger;
        private IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService, IMapper mapper, ILogger<SchedulesController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleDto>> Get()
        {
            var schedules = _scheduleService.GetAll().Select(_mapper.Map<ScheduleDto>);
            if (schedules != null)
                return Ok(schedules);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var schedule = await _scheduleService.GetAsync(id);
            if (schedule != null)
                return Ok(schedule);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScheduleDto dto)
        {
            var schedule = _mapper.Map<Schedule>(dto);
            await _scheduleService.AddAsync(schedule);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ScheduleDto dto)
        {
            var schedule = _mapper.Map<Schedule>(dto);
            schedule.Id = id;
            await _scheduleService.UpdateAsync(schedule);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _scheduleService.DeleteAsync(id);
            return Ok("Deleted");
        }

        [HttpPost("{scheduleId}/group")]
        public async Task<IActionResult> AddGroup(int scheduleId, [FromBody] int groupId)
        {
            await _scheduleService.AddGroupAsync(scheduleId, groupId);
            return Created("localhost", "");
        }
    }
}
