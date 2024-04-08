using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events;

public sealed record RentReservedDomainEvent(Guid rentId) : IDomainEvent;