using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events;

public sealed record RentCompletedDomainEvent(Guid id) : IDomainEvent;