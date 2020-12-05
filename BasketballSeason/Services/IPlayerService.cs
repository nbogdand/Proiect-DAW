using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;

namespace BasketballSeason.Services
{
    public interface IPlayerService
    {
        public Task<List<Player>> GetPlayers();
        public Player GetPlayer(Guid Id);
        public Player CreatePlayer(Player Player);
        public Player UpdatePlayer(Guid Id, Player player);
        public bool DeletePlayer(Guid Id);
    }
}
