using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehicles;


public static class VehicleErrors
{

    public static Error NotFound = new Error("Vehicle.Found", "No existe un vehiculo con este ID");
    

}