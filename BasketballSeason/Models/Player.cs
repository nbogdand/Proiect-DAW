using System;
using BasketballSeason.Models.Base;
using BasketballSeason.Models.OnetoOne;

namespace BasketballSeason.Models
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public int MatchesPlayed { get; set; }

        public string Role { get; set; }

        public Team Team { get; set; }

        public Guid TeamId { get; set; }
    }
}
