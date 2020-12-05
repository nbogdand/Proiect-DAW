using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.TeamRepo
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(MyAppContext myAppContext) : base (myAppContext) { }
    }
}
