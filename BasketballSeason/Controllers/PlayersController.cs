using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Helpers;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.PlayerDTOs;
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
        public async Task<ActionResult<List<Player>>> GetTeamPlayers([FromQuery(Name = "teamId")] Guid TeamId)
        {
            List<Player> Result = (TeamId == null || TeamId == Guid.Empty) ? await _playerService.GetPlayers() : await _playerService.GetTeamPlayers(TeamId);

            if (Result == null)
            {
                return Ok(new List<Player>());
            }
            return Ok(Result);
        }

        [HttpGet("{Id:Guid}")]
        public ActionResult<Player> GetPlayer(Guid Id)
        {
            if (Id == null) return BadRequest();

            Player Result = _playerService.GetPlayer(Id);

            if (Result == null)
            {
                return NotFound();
            }

            return Ok(Result);
        }

        [HttpPost]
        public ActionResult<Player> AddPlayer([FromBody] CreatePlayerDTO createPlayerDTO)
        {
            if (createPlayerDTO.TeamId == null)
            {
                return BadRequest("Missing team id");
            }

            Player Result = _playerService.CreatePlayer(createPlayerDTO);

            if (Result == null)
            {
                return BadRequest("An error has occurred.");
            }

            return Ok(Result);
        }

        [HttpPut]
        public ActionResult<Player> UpdateEmployee(Player player)
        {
            Player existingPlayer = _playerService.UpdatePlayer(player.Id, player);
            if (existingPlayer == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpDelete("{PlayerId}")]
        public ActionResult<bool> DeletePlayer(Guid PlayerId)
        {
            bool wasDeleted = _playerService.DeletePlayer(PlayerId);
            if (wasDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
