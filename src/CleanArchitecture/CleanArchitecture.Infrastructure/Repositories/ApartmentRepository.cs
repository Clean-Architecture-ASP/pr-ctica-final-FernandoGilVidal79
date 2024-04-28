using CleanArchitecture.Domain.Apartments;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}