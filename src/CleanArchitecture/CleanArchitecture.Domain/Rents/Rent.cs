using System.Dynamic;
using System.Net;
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

    public DateTime? RejectDate {get; private set;}

    public DateTime? CompleteDate {get; private set;}

    public DateTime? CancelDate {get; private set;}

    public static Rent Renting(  
        Vehicle vehicle,
        Guid userId,
        DateRange duration,
        DateTime creationTime,
        PriceService priceService
    )
  
    {
        var priceDetail = priceService.CalculatePrice(vehicle, duration);
        var rent = new Rent(Guid.NewGuid(), vehicle.Id, userId, duration,priceDetail.PriceByPeriod, priceDetail.Maintenance, priceDetail.Extras, priceDetail.TotalPrice, RentStatus.Reserved, creationTime);
        rent.RaiseDomainEvent(new RentReservedDomainEvent(rent.Id));
        vehicle.LastRentDate =  creationTime;
        return rent;
    } 
    public Result Confirm(DateTime  actualDate)
    {
        if (RentStatus != RentStatus.Reserved)
        {
            return Result.Failure(RentErrors.NotReserved);
        }
        RentStatus = RentStatus.Confirmed;
        ConfirmationDate = actualDate;
        RaiseDomainEvent (new RentConfirmedDomainEvent(Id));
        return Result.Success();
    }

    public Result Reject(DateTime actualDate)
    {
        if (RentStatus != RentStatus.Reserved)
        {
            return Result.Failure(RentErrors.NotReserved);
        }

        RentStatus = RentStatus.Rejected;
        RejectDate = actualDate;
        RaiseDomainEvent(new RentRejectedDomainEvent(Id));
        return Result.Success();
    }

    public Result Cancel(DateTime actualDate)
    {
        if (RentStatus != RentStatus.Confirmed)
        {
            return Result.Failure(RentErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(actualDate);
        if (currentDate > Duration.Start)
        {
            return Result.Failure(RentErrors.AlreadyStarted);
        }

        RentStatus = RentStatus.Cancelled;
        CancelDate = actualDate;
        RaiseDomainEvent(new RentCancelledDomainEvent(Id));
        return Result.Success();
    }

        public Result Complete(DateTime actualDate)
    {
        if (RentStatus != RentStatus.Confirmed)
        {
            return Result.Failure(RentErrors.NotConfirmed);
        }

        RentStatus = RentStatus.Completed;
        CompleteDate = actualDate;
        RaiseDomainEvent(new RentCompletedDomainEvent(Id));
        return Result.Success();
    }
}