using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Infrastructure.Repositories;


internal sealed class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
