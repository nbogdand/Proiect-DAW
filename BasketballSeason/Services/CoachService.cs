using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.CoachRepo;
using Microsoft.Extensions.Logging;

namespace BasketballSeason.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        private readonly ILogger _logger;

        public CoachService(ICoachRepository coachRepository, ILogger logger)
        {
            _coachRepository = coachRepository;
            _logger = logger;
        }

        public Coach CreateCoach(Coach Coach)
        {
            try
            {
                if (_coachRepository.FindById(Coach.Id) != null)
                {
                    return null;
                }
                _coachRepository.Create(Coach);
                _coachRepository.Save();
                return Coach;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public bool DeleteCoach(Guid Id)
        {
            try
            {
                Coach coach = _coachRepository.FindById(Id);
                if (coach == null)
                {
                    return false;
                }

                _coachRepository.Delete(coach);
                _coachRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return false;
            }
        }

        public Coach GetCoach(Guid Id)
        {
            try
            {
                return _coachRepository.FindById(Id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Task<List<Coach>> GetCoaches()
        {
            try
            {
                return _coachRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Coach UpdateCoach(Guid Id, Coach Coach)
        {
            try
            {
                Coach CurrentCoach = _coachRepository.FindById(Id);

                if (CurrentCoach != null)
                {
                    CurrentCoach.Name = Coach.Name;
                    CurrentCoach.Team = Coach.Team;
                    CurrentCoach.TournamentsWins = Coach.TournamentsWins;

                    _coachRepository.Update(CurrentCoach);
                    _coachRepository.Save();

                    return CurrentCoach;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
