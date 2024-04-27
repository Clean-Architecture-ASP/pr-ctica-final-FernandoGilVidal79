using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Application.Apartments.SearchApartments;


public sealed class SearchApartmentResponse
{
    public AddressResponse? Address {get; private set;}

    public Currency Price {get;}

    public DateTime? LastRentDate {get;}
}