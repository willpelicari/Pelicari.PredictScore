using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pelicari.PredictScore.Core.Services;
using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Web.API.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Web.API.Controllers
{
    [Route("group")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<GroupsController> _logger;
        private IGroupService _groupService;

        public GroupsController(IGroupService groupService, IMapper mapper, ILogger<GroupsController> logger)
        {
            _groupService = groupService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GroupDto>> Get()
        {
            var groups = _groupService.GetAll().Select(_mapper.Map<GroupDto>);
            if (groups != null)
                return Ok(groups);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var group = _mapper.Map<GroupDto>(await _groupService.GetAsync(id));
            if (group != null)
                return Ok(group);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupDto dto)
        {
            var group = _mapper.Map<Group>(dto);
            await _groupService.AddAsync(group);
            return Created("localhost", "");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GroupDto dto)
        {
            var group = _mapper.Map<Group>(dto);
            group.Id = id;
            await _groupService.UpdateAsync(group);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            await _groupService.DeleteAsync(id);
            return Ok("Deleted");
        }

        [HttpPost("{groupId}/user")]
        public async Task<IActionResult> AddContainer(int groupId, [FromBody] int userId)
        {
            await _groupService.AddUserAsync(groupId, userId);
            return Created("localhost", "");
        }
    }
}
