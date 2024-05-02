using BookMe.Domain.Users;

namespace BookMe.Infrastructure.Repositories;
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
