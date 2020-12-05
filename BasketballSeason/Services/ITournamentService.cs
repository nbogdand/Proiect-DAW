using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;

namespace BasketballSeason.Services
{
    public interface ITournamentService
    {
        public List<Tournament> GetTournaments();
        public Tournament GetTournament(Guid Id);
        public Tournament CreateTournament(Guid Id, Tournament Tournament);
        public Tournament UpdateTournament(Guid Id, Tournament Tournament);
        public bool DeleteTournament(Guid Id);
    }
}
