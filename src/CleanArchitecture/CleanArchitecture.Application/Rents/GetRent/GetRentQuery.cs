using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Rents.GetRent;

public sealed record GetRentQuery (Guid rentId) : IQuery<RentResponse>;