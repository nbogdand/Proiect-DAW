using System;
using BasketballSeason.Helpers;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketballSeason.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("{Id:Guid}")]
        public ActionResult<Team> getTeam(Guid Id)
        {
            var existingTeam = _teamService.GetTeam(Id);
            if (existingTeam == null)
            {
                return NotFound();
            }
            return Ok(existingTeam);
        }
    }
}
