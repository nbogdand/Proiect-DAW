using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.PlayerDTOs;

namespace BasketballSeason.Services
{
    public interface IPlayerService
    {
        public Task<List<Player>> GetPlayers();
        public Task<List<Player>> GetTeamPlayers(Guid Id);
        public Player GetPlayer(Guid Id);
        public Player CreatePlayer(CreatePlayerDTO Player);
        public Player UpdatePlayer(Guid Id, Player player);
        public bool DeletePlayer(Guid Id);
    }
}
