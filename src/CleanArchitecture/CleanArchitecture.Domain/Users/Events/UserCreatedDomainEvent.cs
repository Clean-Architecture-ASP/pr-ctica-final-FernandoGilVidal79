using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users.Events;

public sealed record UserCreateDomainEvent(Guid id) : IDomainEvent
{

}
