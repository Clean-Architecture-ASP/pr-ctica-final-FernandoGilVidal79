namespace CleanArchitecture.Domain.Vehicles;

public record Address
(
    string Street,
    string Departure,
    string Country,
    string Province,
    string City
);