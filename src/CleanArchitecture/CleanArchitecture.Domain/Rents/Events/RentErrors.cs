

using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Rents;

public static class RentErrors
{
    public static Error NotFound = new Error("Rent.Found", "El alquiler con el id especificado no fue encontrado");

    public static Error Overlap  = new Error("Rent.Overlap","El alquiler está siendo tomad por dos o más clientes al mismo tiempo");  
    public static Error  NotReserved = new Error("Rent.NotReserved", "El alquiler no está reservado");
    public static Error  NotConfirmed = new Error("Rent.NotConfirmed", "El alquiler no está reservado");
}
}
