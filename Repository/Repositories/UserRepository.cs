using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}