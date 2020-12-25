using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace BasketballSeason.Repositories.TournamentRepo
{
    public class TeamInTournamentRepository: GenericRepository<TeamInTournament>, ITeamInTournamnetRepository
    {
        public TeamInTournamentRepository(MyAppContext myAppContext) : base(myAppContext) { }

        public Task<List<TeamInTournamentDTO>> GetAllTeamsInTournament(Guid tournamnetId)
        {
            return _table.Where(tt => tt.TournamentId == tournamnetId)
                .Include(tt => tt.Team)
                .Select(tt => new TeamInTournamentDTO
                {
                    Id = tt.Id,
                    TeamId = tt.Team.Id,
                    TournamentId = tt.TournamentId,
                    Name = tt.Team.Name,
                    Victories = tt.Victories,
                    Draws = tt.Draws,
                    Defeats = tt.Defeats
                })
                .ToListAsync();
        }
    }
}
