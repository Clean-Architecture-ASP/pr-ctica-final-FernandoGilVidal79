using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events;

public sealed record RentRejectedDomainEvent(Guid id) : IDomainEvent;
