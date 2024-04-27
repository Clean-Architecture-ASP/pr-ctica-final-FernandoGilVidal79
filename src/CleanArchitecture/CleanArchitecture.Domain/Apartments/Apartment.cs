using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Apartments;


public sealed class Apartment : Entity
{
    public Apartment()
    {
        
    }

    public Apartment (Guid id) : base(id)
    {

    }


    public Address? Address {get; private set;}





}