using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models.OnetoOne;

namespace BasketballSeason.Services
{
    public interface ITeamService
    {
        public List<Team> GetTeams();
        public Task<Team> GetTeam(Guid Id);
        public Team CreateTeam(Team Team);
        public Team UpdateTeam(Guid Id, Team Team);
        public bool DeleteTeam(Guid Id);
    }
}
