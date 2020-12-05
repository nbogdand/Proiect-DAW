using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.PlayerRepo
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(MyAppContext myAppContext) : base (myAppContext) { }
    }
}