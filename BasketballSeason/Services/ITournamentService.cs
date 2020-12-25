using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;

namespace BasketballSeason.Services
{
    public interface ITournamentService
    {
        public Task<List<TournamentDTO>> GetAllTournamentsAndTeams();
        public Task<List<Tournament>> GetTournaments();
        public Tournament GetTournament(Guid Id);
        public Tournament CreateTournament(Guid Id, Tournament Tournament);
        public Tournament UpdateTournament(Guid Id, Tournament Tournament);
        public bool DeleteTournament(Guid Id);
    }
}
