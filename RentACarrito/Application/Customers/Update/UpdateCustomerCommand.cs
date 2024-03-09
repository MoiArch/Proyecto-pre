using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

public record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string DuiNumber,
    string PhoneNumber,
    string Departamento,
    string Municipio,
    string Distrito,
    string Direccion,
    bool Active) : IRequest<ErrorOr<Unit>>;