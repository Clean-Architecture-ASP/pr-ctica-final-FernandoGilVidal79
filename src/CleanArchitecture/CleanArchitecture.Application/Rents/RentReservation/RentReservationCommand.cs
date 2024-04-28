
using CleanArchitecture.Application.Abstractions.Messaging;

public record RentReservationCommand(Guid vehicleId, Guid userId, DateOnly dateStart, DateOnly dateEnd) : ICommand<Guid>;