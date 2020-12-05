using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Data;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.CoachRepo
{
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {
        public CoachRepository(MyAppContext myAppContext) : base(myAppContext) { }
    }
}
