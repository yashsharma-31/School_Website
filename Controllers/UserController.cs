using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Api.DMOs;
using School.Api.DTOs;
using School.Api.Interfaces;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _service;

        public UserController(IUserService userService, IAuthService service)
        {
            _userService = userService;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User?>> Register(User request)
        {
            var user = await _service.RegisterAsync(request);
            if (user == null)
            {
                return BadRequest("User already exist");
            }
            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(RequestDto request)
        {
            var token = await _service.LoginAsync(request);
            if (token is null)
                return BadRequest("Wrong Credentials");
            return Ok(token);
        }

        [HttpGet("/user")]
        [Authorize(Roles ="user")]
        public ActionResult get()
        {
            return Ok("You are user");
        }

        [HttpGet("/admin")]
        [Authorize(Roles = "admin")]
        public ActionResult get_info()
        {
            return Ok("You are Admin");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usr = await _userService.GetUserByIdAsync(id);
            if (usr == null) 
                return NotFound("Not Exist in the database");
            return Ok(usr);
        }

    }
}
