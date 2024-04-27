using CleanArchitecture.Api.Controllers.Rents;
using CleanArchitecture.Application.Rents.GetRent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/rents")]
public class RentController : Controller
{
    private readonly ISender _sender;

    public RentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRent (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetRentQuery(id);
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> RentReservation(Guid id, RentReservationRequest rentRequest, CancellationToken cancellationToken)
    {
        var command = new RentReservationCommand(rentRequest.VehicleId, 
                                        rentRequest.UserId, 
                                        rentRequest.StartDate, rentRequest.EndDate);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailue)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetRent), new {Id = result.Value}, result.Value);
    }

}