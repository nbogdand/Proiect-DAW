using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Mapper;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.PlayerDTOs;
using BasketballSeason.Repositories.PlayerRepo;
using BasketballSeason.Repositories.TeamRepo;
using BasketballSeason.Repositories.UserRepo;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;

namespace BasketballSeason.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public PlayerService(
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository,
            IUserRepository userRepository,
            ILogger<PlayerService> logger
        )
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public Player CreatePlayer(CreatePlayerDTO PlayerDTO)
        {
            try
            {
                var ExistingTeam = _teamRepository.FindById(new Guid(PlayerDTO.TeamId));

                if (ExistingTeam == null)
                {
                    return null;
                }

                Player newPlayer = PlayerDTO.toPlayer();
                _playerRepository.Create(newPlayer);
                _playerRepository.Save();

                NotifyAll(newPlayer);

                return newPlayer;
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

        private async void NotifyAll(Player newPlayer)
        {
            try
            {
                List<User> users = await _userRepository.GetAll();

                if (users != null)
                {
                    foreach (User user in users)
                    {
                        if (user.FcmToken != null)
                        {
                            await SendNotification(newPlayer, user.FcmToken);
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
         
        }

        private async Task SendNotification(Player NewPlayer, string Token)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "New Player",
                    Body = $"{NewPlayer.Name} has entered the season!"
                },

                Token = Token
            };
            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
