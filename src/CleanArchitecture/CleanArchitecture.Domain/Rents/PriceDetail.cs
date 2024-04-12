using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Domain.Rents;

public record PriceDetail(
    Currency PriceByPeriod,
    Currency Maintenance,
    Currency Extras,
    Currency TotalPrice
);
