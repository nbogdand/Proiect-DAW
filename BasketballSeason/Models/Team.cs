using System;
using System.Collections.Generic;
using BasketballSeason.Models.Base;

namespace BasketballSeason.Models.OnetoOne
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }

        public Coach Coach { get; set; }

        public ICollection<Player> Players { get; set; }

        public Guid CoachId { get; set; }

        public int Victories { get; set; }

        public int Defeats { get; set; }

        public int Draws { get; set; }

        public int TournamentWins { get; set; }

        public ICollection<TeamInTournament> TeamInTournament { get; set; }
    }
}
