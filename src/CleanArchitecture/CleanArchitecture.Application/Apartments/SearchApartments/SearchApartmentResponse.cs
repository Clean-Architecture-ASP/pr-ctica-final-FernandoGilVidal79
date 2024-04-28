using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Application.Apartments.SearchApartments;

public sealed class SearchApartmentResponse
{
    public Guid Id {get; init;}

    public AddressResponse Address {get; set;}

    public Currency? Price { get; init; }

    public DateTime? LastRentDate { get; init; }
}