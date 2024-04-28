using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents.Events;

public sealed class RentCancelledDomainEvent (Guid RentId) : IDomainEvent;