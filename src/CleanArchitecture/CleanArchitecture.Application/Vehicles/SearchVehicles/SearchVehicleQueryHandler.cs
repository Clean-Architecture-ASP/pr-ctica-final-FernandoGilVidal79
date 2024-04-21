using System.Reflection.Metadata.Ecma335;
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
                v.price AS Price,
                v.currency_type_price as CurrencyType,
                a.address_countr AS Country,
                a.address_city AS City,
                a.address_province AS Province,
                a.address_street as Street
            FROM
                Vehicles AS v
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM rents AS r
                WHERE 
                    b.vehicle_id = v.id
                    b.duration_start <= @EndDate AND
                    b.duration_end >= @StartDate AND
                    b.status = ANY(@ActiveRentStatuses)
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