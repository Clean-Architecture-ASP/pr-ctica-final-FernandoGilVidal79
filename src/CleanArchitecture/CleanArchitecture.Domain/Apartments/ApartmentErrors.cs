using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Apartments;

public static class VehicleErrors
{
    public static Error NotFound = new Error("Apartment.Not.Found", "No existe un Apartamento con este ID");  
}