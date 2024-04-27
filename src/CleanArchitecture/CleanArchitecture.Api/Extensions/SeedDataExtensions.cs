using Bogus;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Vehicles;
using Dapper;

namespace CleanArchitecture.Api.Extensions;


public static class SeedDataExtensions
{


    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetService<ISqlConnectionFactory>();

        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> vehicles = new();
        for (var i=0; i < 100; i++)
        {
            vehicles.Add(new {
                Id = Guid.NewGuid(),
                vin = faker.Vehicle.Vin(),
                Model = faker.Vehicle.Model(),
                Country = faker.Address.Country(),
                Province = faker.Address.County(),
                City = faker.Address.City(),
                Street = faker.Address.StreetAddress(),
                Departure = faker.Address.State(),
                TotalPrice = faker.Random.Decimal(1000,20000),
                CurrencyType = "EUR",
                PriceMaintenance = faker.Random.Decimal(100,200),
                PriceMaintenanceCurrencyType = "EUR",
                Extras = new List<int> { (int)Extra.Wifi, (int)Extra.AirConditioning },
                LasDate = DateTime.MinValue
            });
        }

        const string sql = """
            INSERT INTO public.vehicles
             (id, vin, model, address_street, address_departure, 
              address_country, address_city, price_quantity, price_currency_type,
              maintenance_quantity, maintenance_currency_type, last_rent_date, extras)

            VALUES (@id, @vin, @model, @street, @departure, @country, @city, @TotalPrice, @currencytype,
            @PriceMaintenance, @PriceMaintenanceCurrencyType, @LasDate, @extras)
        """;
        
        connection.Execute(sql, vehicles);

    }
}