using Application.Customers.Create;
using Application.Customers.Update;
using Application.Customers.GetById;
using Application.Customers.Delete;
using Application.Customers.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;


namespace Web.API.Controllers;

[Route("Customers")]
public class Customers : ApiController
{
    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());

        return customersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customerResult = await _mediator.Send(new GetCustomerByIdQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            customerId => Ok(customerId),
            errors => Problem(errors)
        );
    }

      [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if(id != command.Id)
            {
                List<Error> errors = new() { 
                    Error.Validation("Customer.Id", "THe request Id does nt match with the url Id")
                };
                return Problem(errors);
            }

            var updateCustomerResult = await _mediator.Send(command);

            return updateCustomerResult.Match(
                customers => Ok(),
                errors => Problem(errors)
            );
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteCustomerCommand(id));

        return deleteResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }
}