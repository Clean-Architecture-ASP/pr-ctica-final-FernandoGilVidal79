using CleanArchitecture.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Apartments;



[ApiController]
[Route("api/apartments")]
public class ApartmentController : Controller
{
    private readonly ISender _sender;

    public ApartmentController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet]
    public async Task<IActionResult> SearchApartments(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        var query = new SearchApartmentQuery(startDate,endDate);
        var results = await _sender.Send(query, cancellationToken);
        return Ok(results.Value);
    }
}
