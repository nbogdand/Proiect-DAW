using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Mapper;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.TournamentDTOs;
using BasketballSeason.Repositories.TeamRepo;
using BasketballSeason.Repositories.TournamentRepo;
using Microsoft.Extensions.Logging;

namespace BasketballSeason.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamInTournamnetRepository _teamInTournamnetRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger _logger;

        public TournamentService(
            ITournamentRepository tournamentRepository, 
            ITeamInTournamnetRepository teamInTournamnetRepository,
            ITeamRepository teamRepository,
            ILogger<TournamentService> logger
        )
        {
            _tournamentRepository = tournamentRepository;
            _teamInTournamnetRepository = teamInTournamnetRepository;
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public async Task<List<TournamentDTO>> GetAllTournamentsAndTeams()
        {
            try
            {
                List<Tournament> tournaments = await _tournamentRepository.GetAll();
                List<TournamentDTO> response = new List<TournamentDTO>();

                foreach(Tournament t in tournaments)
                {
                    List<TeamInTournamentDTO> teamsInTournament = await _teamInTournamnetRepository.GetAllTeamsInTournament(t.Id);
                    //t.TeamInTournament = teamsInTournament.ConvertAll(tt => tt.toTeamInTournament());
                    response.Add(new TournamentDTO {
                        Name = t.Name,
                        TeamInTournament = teamsInTournament
                    });
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public async Task<List<Tournament>> GetTournaments()
        {
            try
            {
                return await _tournamentRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }

        public Tournament CreateTournament(Guid Id, Tournament Tournament)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTournament(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Tournament GetTournament(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Tournament UpdateTournament(Guid Id, Tournament Tournament)
        {
            throw new NotImplementedException();
        }
    }
}
