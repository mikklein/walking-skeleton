using WalkingSkeleton.API.DAL.core;
using WalkingSkeleton.API.Models;

namespace WalkingSkeleton.API.DAL
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context){ }
    }
}