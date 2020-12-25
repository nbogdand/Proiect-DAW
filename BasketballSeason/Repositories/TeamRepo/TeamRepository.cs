using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models.OnetoOne;
using Microsoft.EntityFrameworkCore;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.TeamRepo
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(MyAppContext myAppContext) : base (myAppContext) { }

        public Team GetTeam(Guid Id)
        {
            return _table.Where(team => team.Id == Id)
                .Include(team => team.Coach)
                .Include(team => team.Players)
                .FirstOrDefault();
        }
    }
}
