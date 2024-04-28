using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Shared;
using Dapper;

namespace CleanArchitecture.Application.Apartments.SearchApartments;


internal sealed class SearchApartmentQueryHandler : IQUeryHandler<SearchApartmentQuery, IReadOnlyList<SearchApartmentResponse>>
{

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchApartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Domain.Abstractions.Result<IReadOnlyList<SearchApartmentResponse>>> Handle(SearchApartmentQuery request, CancellationToken cancellationToken)
    {
        
        if (request.startDate > request.endDate)
        {
            return new List<SearchApartmentResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
        SELECT 
            a.id AS Id,
            a.price_quantity AS Price,
            a.address_country AS Country,
            a.address_city AS City,
            a.address_province AS Province,
            a.address_street as Street
        FROM
            Apartments AS a
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM rents AS r
            WHERE 
                r.vehicule_id = a.id AND
                r.duration_start <= @EndDate AND
                r.duration_end >= @StartDate 
        ) 
            


        """
        ;


        var apartments = await connection.QueryAsync<SearchApartmentResponse, AddressResponse, SearchApartmentResponse>
         (sql, (vehicle, direction) =>
         {
             vehicle.Address = direction;
             return vehicle;
         },
         new
         {
             StartDate = request.startDate,
             EndDate = request.endDate
         },
        splitOn: "Country"

           );

        return apartments.ToList();



    }
}
