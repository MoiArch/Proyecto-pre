using Application.Vehiculos.Create;
using Application.Vehiculos.Update;
using Application.Vehiculos.GetById;
using Application.Vehiculos.Delete;
using Application.Vehiculos.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace Web.API.Controllers;

[Route("Vehiculo")]
public class Vehiculos : ApiController
{
    private readonly ISender _mediator;

    public Vehiculos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehiculosResult = await _mediator.Send(new GetAllVehiculosQuery());

        return vehiculosResult.Match(
            vehiculos => Ok(vehiculos),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vehiculoResult = await _mediator.Send(new GetVehiculoByIdQuery(id));

        return vehiculoResult.Match(
            vehiculo => Ok(vehiculo),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehiculoCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            vehiculoId => Ok(vehiculoId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehiculoCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Vehiculo.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            vehiculoId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteVehiculoCommand(id));

        return deleteResult.Match(
            vehiculoId => NoContent(),
            errors => Problem(errors)
        );
    }
}