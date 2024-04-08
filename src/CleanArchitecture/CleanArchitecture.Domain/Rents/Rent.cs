using System.Dynamic;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents.Events;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents;

public sealed class Rent : Entity
{


    public Rent(Guid id,
        Guid vehicleId,
        Guid userId,
        DateRange duration,
        Currency price,
        Currency maintenancePrice,
        Currency extraPrices,
        Currency totalPrice,
        RentStatus rentStatus,
        DateTime creationTime
    
    
    ) : base (id)
    {
        VehiculeId = vehicleId;
        UserId = userId;
        Duration = duration;
        Price = price;
        MaintenancePrice = maintenancePrice;
        ExtraPrice = extraPrices;
        TotalPrice = totalPrice;
        RentStatus = rentStatus;
        CreationDate = creationTime;
        
    }
    public Guid VehiculeId{get; private set;}

    public Guid UserId {get; private set;}

    public Currency Price {get; private set;}

    public Currency MaintenancePrice {get; private set;}

    public Currency ExtraPrice {get; private set;}

    public Currency TotalPrice {get; private set;}

    public RentStatus RentStatus {get; private set;}

    public DateRange? Duration {get; private set;}

    public DateTime? CreationDate {get; private set;}

    public DateTime? ConfirmationDate {get; private set;}

    public DateTime? DenegationDate {get; private set;}

    public DateTime? CompleteDate {get; private set;}

    public DateTime? CancelDate {get; private set;}

    public static Rent Renting(
    
        Guid vehicleId,
        Guid userId,
        DateRange duration,
        DateTime creationTime,
        PriceDetail priceDetail
    )
    {
        var rent = new Rent(Guid.NewGuid(), vehicleId, userId, duration,priceDetail.PriceByPeriod, priceDetail.Maintenance, priceDetail.Extras, priceDetail.TotalPrice, RentStatus.Reserved, creationTime);
        rent.RaiseDomainEvent(new RentReservedDomainEvent(rent.Id));

        return rent;
    } 
}