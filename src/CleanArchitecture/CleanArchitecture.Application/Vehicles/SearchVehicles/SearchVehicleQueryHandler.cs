
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents;
using Dapper;

namespace CleanArchitecture.Application.Vehicles.SearchVehicles;

internal sealed class SearchVehiclesQueryHandler : IQUeryHandler<SearchVehiclesQuery, IReadOnlyList<SearchVehicleResponse>>
{

    private static readonly int[] ActiveRentStatuses =
        {
            (int)RentStatus.Reserved, 
            (int)RentStatus.Confirmed,
            (int)RentStatus.Completed
        };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchVehiclesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<SearchVehicleResponse>>> Handle(SearchVehiclesQuery request, CancellationToken cancellationToken)
    {
        if (request.startDate > request.endDate)
        {
            return new List<SearchVehicleResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
        SELECT 
            v.id AS Id,
            v.model AS Model,
            v.vin AS Vin,
            v.price_quantity AS Price,
            v.price_currency_type as CurrencyType,
            v.address_country AS Country,
            v.address_city AS City,
            v.address_province AS Province,
            v.address_street as Street
        FROM
            Vehicles AS v
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM rents AS r
            WHERE 
                r.vehicule_id = v.id AND
                r.duration_start <= @EndDate AND
                r.duration_end >= @StartDate AND
                r.rent_status = ANY(@ActiveRentStatuses)
        )

        """;

        var vehicles = await connection.QueryAsync<SearchVehicleResponse, AddressResponse, SearchVehicleResponse>
        ( sql, (vehicle, direction) => 
        {
            vehicle.Address = direction;
            return vehicle;
        },
        new 
        {
            StartDate = request.startDate,
            EndDate = request.endDate,
            ActiveRentStatuses
        },
        splitOn: "Country"

         );

         return vehicles.ToList();
    }   
}