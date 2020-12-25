using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models;
using BasketballSeason.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace BasketballSeason.Repositories.PlayerRepo
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(MyAppContext myAppContext) : base (myAppContext) { }

        public Task<List<Player>> GetTeamPlayers(Guid TeamId)
        {
            return _table.Where(player => player.TeamId == TeamId).ToListAsync();
        }
    }
}