using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Models.DTOs.PlayerDTOs
{
    public class CreatePlayerDTO
    {
        public string Name { get; set; }

        public long Birthdate { get; set; }

        public int MatchesPlayed { get; set; }

        public string Role { get; set; }

        public string TeamId { get; set; }
    }
}
