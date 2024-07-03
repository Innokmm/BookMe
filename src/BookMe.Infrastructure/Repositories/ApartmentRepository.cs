using BookMe.Domain.Apartments;

namespace BookMe.Infrastructure.Repositories;
internal class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
