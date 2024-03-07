using Application.Vehiculos.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;
[Route("Vehiculos")]
public class Vehiculos : ApiController
{
    private readonly ISender _mediator;

    public Vehiculos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehiculoCommand command)
    {
        var createVehiculoResult = await _mediator.Send(command);

        return createVehiculoResult.Match(
            vehiculo =>Ok(),
            errors => Problem(errors));
    }
}