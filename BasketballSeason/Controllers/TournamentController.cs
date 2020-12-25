using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Helpers;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;
using BasketballSeason.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketballSeason.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController: ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TournamentDTO>>> GetAllTournaments()
        {
            List<TournamentDTO> Result = await _tournamentService.GetAllTournamentsAndTeams();

            if (Result == null)
            {
                return Ok(new List<TournamentDTO>());
            }
            return Ok(Result);
        }
    }
}
