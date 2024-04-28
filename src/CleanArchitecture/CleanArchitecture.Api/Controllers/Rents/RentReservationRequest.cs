namespace CleanArchitecture.Api.Controllers.Rents;

public sealed record RentReservationRequest (
    Guid VehicleId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
);