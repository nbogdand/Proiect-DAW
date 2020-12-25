using System;
using System.Collections.Generic;
using BasketballSeason.Models.Base;

namespace BasketballSeason.Models
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }

        public List<TeamInTournament> TeamInTournament { get; set; }
    }
}
