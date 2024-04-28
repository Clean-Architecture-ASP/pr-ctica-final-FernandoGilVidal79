using CleanArchitecture.Application.Vehicles.SearchVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Vehicles;

[ApiController]
[Route("api/vehicles")]
public class VehicleController : Controller
{
    private readonly ISender _sender;

    public VehicleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> SearchVehicles(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        var query = new  SearchVehiclesQuery(startDate,endDate);
        var results = await _sender.Send(query, cancellationToken);
        return Ok(results.Value);
    }
}