using ErrorOr;
using MediatR;

namespace Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    string LastName,
    string Email,
    string DuiNumber,
    string PhoneNumber,
    string Departamento,
    string Municipio,
    string Distrito,
    string Direccion
) : IRequest<ErrorOr<Unit>>;  
