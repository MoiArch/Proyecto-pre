using Application.Reservaciones.Create;
using Application.Reservaciones.Update;
using Application.Reservaciones.GetById;
using Application.Reservaciones.Delete;
using Application.Reservaciones.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;


namespace Web.API.Controllers;

[Route("Reservaciones")]
public class Reservaciones : ApiController
{
    private readonly ISender _mediator;

    public Reservaciones(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservacionesResult = await _mediator.Send(new GetAllReservacionesQuery());

        return reservacionesResult.Match(
            reservaciones => Ok(reservaciones),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reservacionResult = await _mediator.Send(new GetReservacionByIdQuery(id));

        return reservacionResult.Match(
            reservacion => Ok(reservacion),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservacionCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            reservacionId => Ok(reservacionId),
            errors => Problem(errors)
        );
    }

      [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateReservacionCommand command)
        {
            if(id != command.Id)
            {
                List<Error> errors = new() { 
                    Error.Validation("Reservacion.Id", "THe request Id does nt match with the url Id")
                };
                return Problem(errors);
            }

            var updateReservacionResult = await _mediator.Send(command);

            return updateReservacionResult.Match(
                reservaciones => Ok(),
                errors => Problem(errors)
            );
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteReservacionCommand(id));

        return deleteResult.Match(
            reservacionId => NoContent(),
            errors => Problem(errors)
        );
    }
}