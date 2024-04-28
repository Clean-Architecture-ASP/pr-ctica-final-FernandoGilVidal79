using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Application.Rents.GetRent;

internal sealed class GetRentQueryHandler : IQUeryHandler<GetRentQuery, RentResponse>
{

    private readonly ISqlConnectionFactory  _sqlConnectionFactory;    

    public GetRentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;   
    }
    public async Task<Result<RentResponse>> Handle(GetRentQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

         var sql = """
            SELECT 
                id AS Id,
                vehicle_id AS VehicleId,
                user_id AS UserId,
                status AS Status, 
                price_By_Period AS RentPrice,
                price_By_Period_Currency_Type AS RentCurrencyType,
                price_maintenance AS MaintenancePrice,
                price_maintenance_currency_type AS CurrencyTypeMaintenance,
                price_extras AS ExtraPrice,
                price_extras_currency_type AS PriceExtrasCurrencyType,
                price_total AS TotalPrice, 
                price_total_currency_type AS PriceTotalCurrencyType,
                duration_start AS StartDuration,
                duration_end AS EndDuration,
                creation_date AS CreationDate
            FROM 
                rents
            WHERE
                id = @rentId
        """;

        var rent = await connection.QueryFirstOrDefaultAsync<RentResponse>(sql, new {
            request.rentId
        });

        return rent;
    }
}
