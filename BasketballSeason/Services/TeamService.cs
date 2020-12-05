using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.TeamRepo;
using Microsoft.Extensions.Logging;

namespace BasketballSeason.Services
{
    public class TeamService : ITeamService
    {

        private readonly ITeamRepository _teamRepository;
        private readonly ILogger _logger;

        public TeamService(ITeamRepository teamRepository, ILogger<TeamService> logger)
        {
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public Team CreateTeam(Team Team)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeam(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Team GetTeam(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetTeams()
        {
            throw new NotImplementedException();
        }

        public Team UpdateTeam(Guid Id, Team Team)
        {
            throw new NotImplementedException();
        }
    }
}
