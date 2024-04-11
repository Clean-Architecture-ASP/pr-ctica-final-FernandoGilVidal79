using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events;


public sealed record RentConfirmedDomainEvent(Guid rentId): IDomainEvent
{}