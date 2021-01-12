using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BasketballSeason.Helpers;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs;
using BasketballSeason.Models.DTOs.UserDTOs;
using BasketballSeason.Services.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BasketballSeason.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        // private readonly UserManager<User> _userManager;

        public UsersController(IUserService userService /*,UserManager<User> userManager*/)
        {
            _userService = userService;
            //_userManager = userManager;
        }

        [HttpPost("login")]
        public IActionResult Authentificate([FromBody] UserRequestDTO user)
        {
            var result = _userService.Authentificate(user);

            if (result == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }

        [HttpPost("register")]
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

        [HttpPost("saveFcmToken") ]
        [Authorize]
        public IActionResult SaveFcmToken([FromBody] SaveFcmTokenDTO fcmTokenRequest)
        {
            
            try
            {
                if (_userService.SaveFcmToken(fcmTokenRequest, Guid.Parse(fcmTokenRequest.userId)))
                {
                    return Ok("Token saved!");
                }
                else
                {
                    return StatusCode(500);
                }
            } catch (Exception e)
            {
                return BadRequest("User not found!");
            }
        }

        protected Guid? GetUserId()
        {
            try
            {
                // return Guid.Parse(this.User.Claims.First(i => i.Type == "id").Value);
                // return Guid.Parse(_userManager.GetUserId(HttpContext.User));
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    if (identity.FindFirst("id").Value == null)
                    {
                        return null;
                    }

                    return Guid.Parse(identity.FindFirst("id").Value);
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet()]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
