using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Apartments;


public sealed class Apartment : Entity
{
    public Apartment()
    {
        
    }

    public Apartment (Guid id, Address? address, Currency price,  DateTime? lastRentDate) : base(id)
    {
        Address = address;
        Price = price;
        LastRentDate = lastRentDate;
    }


    public Address? Address {get; private set;}

    public Currency Price {get; private set;}

    public DateTime? LastRentDate {get; internal set;}

}