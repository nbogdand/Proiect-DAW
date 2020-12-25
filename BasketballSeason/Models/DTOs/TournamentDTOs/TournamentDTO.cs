using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Models.DTOs.TournamentDTOs
{
    public class TournamentDTO
    {
        public string Name { get; set; }

        public List<TeamInTournamentDTO> TeamInTournament { get; set; }
    }
}
