using System.Linq;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;


internal sealed class RentRepository : Repository<Rent>, IRentRepository
{

    private static readonly RentStatus[] ActiveRentStatuses =
    {   
        RentStatus.Reserved,
        RentStatus.Confirmed,
        RentStatus.Completed
    };

    public RentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOverlappingAsync(Vehicle vehicle, DateRange duration, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Rent>().AnyAsync(rent => rent.VehiculeId == vehicle.Id &&
        rent.Duration!.Start <= duration.End &&
        rent.Duration!.End >= duration.End &&
        ActiveRentStatuses.Contains(rent.RentStatus), cancellationToken);
        


    }
}
