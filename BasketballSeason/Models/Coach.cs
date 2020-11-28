using System;
using BasketballSeason.Models.Base;

namespace BasketballSeason.Models.OnetoOne
{
    public class Coach : BaseEntity
    {
        public string Name { get; set; }

        public string TournamentsWins { get; set; } 

        public Team Team { get; set; }
    }
}
