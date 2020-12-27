using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Repositories.PlayerRepo;
using Microsoft.Extensions.Logging;

namespace BasketballSeason.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger _logger;

        public PlayerService(IPlayerRepository playerRepository, ILogger<PlayerService> logger)
        {
            _playerRepository = playerRepository;
            _logger = logger;
        }

        public Player CreatePlayer(Player Player)
        {
            try
            {
                var ExistingPlayer = _playerRepository.FindById(Player.Name);

                if (ExistingPlayer != null)
                {
                    return null;
                }

                _playerRepository.Create(Player);
                _playerRepository.Save();

                return Player;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public bool DeletePlayer(Guid Id)
        {
            try
            {
                var ExistingPlayer = _playerRepository.FindById(Id);

                if (ExistingPlayer == null)
                {
                    return false;
                }

                _playerRepository.Delete(ExistingPlayer);
                _playerRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return false;
            }
        }

        public Player GetPlayer(Guid Id)
        {
            try
            {
                return _playerRepository.FindById(Id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Task<List<Player>> GetPlayers()
        {
            try
            {
                return _playerRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Task<List<Player>> GetTeamPlayers(Guid TeamId)
        {
            try
            {
                return _playerRepository.GetTeamPlayers(TeamId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Player UpdatePlayer(Guid Id, Player Player)
        {
            try
            {
                var ExistingPlayer = _playerRepository.FindById(Id);

                if (ExistingPlayer == null)
                {
                    return null;
                }

                ExistingPlayer.MatchesPlayed = Player.MatchesPlayed;
                ExistingPlayer.Name = Player.Name;
                ExistingPlayer.Role = Player.Role;

                _playerRepository.Update(ExistingPlayer);
                _playerRepository.Save();

                return ExistingPlayer;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
