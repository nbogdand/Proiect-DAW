using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;

namespace BasketballSeason.Mapper
{
    public static class TeamInTournamentMapper
    {
        public static TeamInTournament toTeamInTournament(this TeamInTournamentDTO teamInTournamentDTO)
        {
            return new TeamInTournament
            {
               Id = teamInTournamentDTO.Id,
               TournamentId = teamInTournamentDTO.TournamentId,
               TeamId = teamInTournamentDTO.TeamId,
               Victories = teamInTournamentDTO.Victories,
               Draws = teamInTournamentDTO.Draws,
               Defeats = teamInTournamentDTO.Defeats
            };
        }
    }
}
