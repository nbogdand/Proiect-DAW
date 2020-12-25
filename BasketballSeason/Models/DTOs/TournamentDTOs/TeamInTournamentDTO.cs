using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Models.DTOs.TournamentDTOs
{
    public class TeamInTournamentDTO
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public int Victories { get; set; }
        public int Draws { get; set; }
        public int Defeats { get; set; }
    }
}
