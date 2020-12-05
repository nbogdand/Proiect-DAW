using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models.OnetoOne;

namespace BasketballSeason.Services
{
    public interface ICoachService
    {
        public Task<List<Coach>> GetCoaches();
        public Coach GetCoach(Guid Id);
        public Coach CreateCoach(Coach Coach);
        public Coach UpdateCoach(Guid Id, Coach Coach);
        public bool DeleteCoach(Guid Id);
    }
}
