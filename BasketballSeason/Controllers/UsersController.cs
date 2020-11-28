using System;
using BasketballSeason.Helpers;
using BasketballSeason.Models.DTOs;
using BasketballSeason.Models.DTOs.UserDTOs;
using BasketballSeason.Services.UserS;
using Microsoft.AspNetCore.Mvc;

namespace BasketballSeason.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentificate")]
        public IActionResult Authentificate([FromBody] UserRequestDTO user)
        {
            var result = _userService.Authentificate(user);

            if (result == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] CreateUserRequestDTO userRequest)
        {
            var Result = _userService.Register(userRequest);

            if (Result)
            {
                return Ok();
            } else
            {
                return Conflict();
            }
        }

        [HttpGet()]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
