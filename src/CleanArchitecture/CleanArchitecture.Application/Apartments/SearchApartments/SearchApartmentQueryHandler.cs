using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Apartments.SearchApartments;


internal sealed class SearchApartmentQueryHandler : IQUeryHandler<SearchApartmentQuery, IReadOnlyList<SearchApartmentResponse>>
{

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchApartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public Task<Domain.Abstractions.Result<IReadOnlyList<SearchApartmentResponse>>> Handle(SearchApartmentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
