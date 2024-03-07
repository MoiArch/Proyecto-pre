using Application.Reservaciones.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;
[Route("Reservaciones")]
public class Reservaciones : ApiController
{
    private readonly ISender _mediator;

    public Reservaciones(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservacionCommand command)
    {
        var createReservacionResult = await _mediator.Send(command);

        return createReservacionResult.Match(
            reservacion =>Ok(),
            errors => Problem(errors));
    }
}