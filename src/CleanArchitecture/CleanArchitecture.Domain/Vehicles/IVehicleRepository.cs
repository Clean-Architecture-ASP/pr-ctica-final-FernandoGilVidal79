namespace CleanArchitecture.Domain.Vehicles;

public interface VehicleRepository

{
    Task<Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}