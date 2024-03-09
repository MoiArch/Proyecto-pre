using Customers.Common;
using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;


internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ErrorOr<CustomerResponse>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetByIdAsync(new CustomerId(query.Id)) is not Customer customer)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        return new CustomerResponse(
            customer.Id.Value, 
            customer.FullName, 
            customer.Email,
            customer.DuiNumber.Value,
            customer.PhoneNumber.Value,
            new AddressResponse(customer.Address.Departamento,
            customer.Address.Municipio,
            customer.Address.Distrito,
            customer.Address.Direccion),
            customer.Active
            );
    }
}