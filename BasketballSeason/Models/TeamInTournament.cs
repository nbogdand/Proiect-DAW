using System;
using BasketballSeason.Models.Base;
using BasketballSeason.Models.OnetoOne;

namespace BasketballSeason.Models
{
    public class TeamInTournament : BaseEntity
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public int Draws { get; set; }
     }
}
