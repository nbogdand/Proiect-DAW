using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.TournamentRepo
{
    public interface ITeamInTournamnetRepository: IGenericRepository<TeamInTournament>
    {
        public Task<List<TeamInTournamentDTO>> GetAllTeamsInTournament(Guid tournamnetId);
    }
}
