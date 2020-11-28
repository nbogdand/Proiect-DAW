
using BasketballSeason.Data;
using BasketballSeason.Models;
using BasketballSeason.Repositories.GenericRepo;

namespace BasketballSeason.Repositories.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyAppContext appContext) : base(appContext) { }
   
    }
}
