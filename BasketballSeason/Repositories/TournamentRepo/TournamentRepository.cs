using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.TournamentRepo
{
    public class TournamentRepository: GenericRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(MyAppContext myAppContext) : base(myAppContext) { }
    }
}
