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
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<UserController> _logger;
        private IService<User> _userService;

        public UserController(IService<User> userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute] int userId)
        {
            if (userId == 0)
                return BadRequest();
            var user = await _userService.GetAsync(userId);
            if(user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = _userService.GetAll();
            if (users != null)
                return Ok(users);
            return NotFound();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(int userId, UserDto dto)
        {
            if (userId == 0)
                return BadRequest();
            var user = _mapper.Map<User>(dto);
            user.Id = userId;
            await _userService.UpdateAsync(user);
            return Ok("Updated");
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userService.AddAsync(user);
            return Created("localhost","");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] int userId)
        {
            if (userId == 0)    
                return BadRequest();
            await _userService.DeleteAsync(userId);
            return Ok("Deleted");
        }
    }
}
