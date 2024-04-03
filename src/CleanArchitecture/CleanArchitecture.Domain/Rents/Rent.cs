using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents;

public sealed class Rent : Entity
{


    public Rent(Guid id) : base (id)
    {
        
    }

    public RentStatus RentStatus {get; private set;}
}