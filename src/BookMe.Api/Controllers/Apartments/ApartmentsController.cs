using BookMe.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookMe.Api.Controllers.Apartments;
[Route("api/apartments")]
[ApiController]
public class ApartmentsController : ControllerBase
{
    private readonly ISender _sender;

    public ApartmentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> SearchApartments(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken)
    {
        SearchApartmentsQuery query = new SearchApartmentsQuery(startDate, endDate);

        Domain.Abstractions.Result<IReadOnlyList<ApartmentResponse>> result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}
