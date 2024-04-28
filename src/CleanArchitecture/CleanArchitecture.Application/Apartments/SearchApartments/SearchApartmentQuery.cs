using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Apartments.SearchApartments;


public sealed record SearchApartmentQuery (DateOnly startDate, DateOnly endDate) : IQuery<IReadOnlyList<SearchApartmentResponse>>;