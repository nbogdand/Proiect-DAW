using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models.OnetoOne;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.CoachRepo
{
    public interface ICoachRepository : IGenericRepository<Coach>
    {
    }
}
