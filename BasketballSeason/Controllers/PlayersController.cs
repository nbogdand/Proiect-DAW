using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Helpers;
using BasketballSeason.Models;
using BasketballSeason.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketballSeason.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            IEnumerable<Player> Result = await _playerService.GetPlayers();

            if (Result == null)
            {
                return Ok(new List<Player>());
            }
            return Ok(Result);
        }

        [HttpGet("{PlayerId}")]
        public ActionResult<Player> GetPlayer(String Id)
        {
            Player Result = _playerService.GetPlayer(Guid.Parse(Id));

            if (Result == null)
            {
                return NotFound(Id);
            }

            return Ok(Result);
        }

    }
}
