using System.Security.Cryptography;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents;

public class PriceService
{
    public PriceDetail CalculatePrice(Vehicle vehicle, DateRange period)
    {
        var currencyType = vehicle.Price!.currencyType;
        var priceByPeriod = new Currency(period.DaysRent * vehicle.Price.quantity, currencyType);

        decimal percentageChange = 0;
        foreach (var extra in vehicle.Extras)
        {
            percentageChange += extra switch
            {
             Extra.AppleCar or Extra.AndroidCar => 0.5m,
             Extra.AirConditioning => 0.01m,
             Extra.Maps => 0.01m,
             _ => 0
            };
        }
        var extraCharger = Currency.Zero(currencyType);

        if (percentageChange > 0)
        {
            extraCharger = new Currency(priceByPeriod.quantity * percentageChange, currencyType);
        }

        var totalPrice = Currency.Zero();
        totalPrice += priceByPeriod;
        if (!vehicle!.Maintenance!.IsZero())
        {
            totalPrice += vehicle.Maintenance;
        }

        totalPrice += extraCharger;

        return new PriceDetail(priceByPeriod, vehicle.Maintenance, extraCharger, totalPrice);        

    }
}