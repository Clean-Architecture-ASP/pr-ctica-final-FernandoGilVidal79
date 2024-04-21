namespace CleanArchitecture.Application.Rents.GetRent;

public sealed class RentResponse
{
    public Guid Id {get; init;}    

    public Guid UserId {get; init;}

    public Guid VehicleId {get; init;}

    public int status {get; init;}

    public decimal RentPrice {get; init;}
    
    public string? CurrencyRentType  {get; init;}

    public decimal MaintenancePrice {get; init;}

    public string? CurrenctMaintenanceType {get; init;}

    public decimal ExtrasPrice {get; init;}

    public string? CurrencyExtrasType {get; init;}

    public decimal TotalPrice {get; init;}

    public string? CurrencyTotalPriceType {get; init;}

    public DateOnly DurationStart {get; set;}

    public DateOnly DurationEnd {get; set;}

    public DateTime CreationDate {get; init;}

}