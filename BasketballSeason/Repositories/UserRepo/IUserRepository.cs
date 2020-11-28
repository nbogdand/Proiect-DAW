using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.UserRepo
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
