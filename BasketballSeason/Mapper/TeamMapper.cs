using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs.PlayerDTOs;

namespace BasketballSeason.Mapper
{
    public static class PlayerMapper
    {
        public static Player toPlayer(this CreatePlayerDTO createPlayerDTO)
        {
            DateTime PlayerBirthdate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            PlayerBirthdate = PlayerBirthdate.AddSeconds(createPlayerDTO.Birthdate).ToLocalTime();

            return new Player
            {
                Name = createPlayerDTO.Name,
                Role = createPlayerDTO.Role,
                Birthdate = PlayerBirthdate,
                MatchesPlayed = createPlayerDTO.MatchesPlayed,
                TeamId = new Guid(createPlayerDTO.TeamId)
            };
        }
    }
}
