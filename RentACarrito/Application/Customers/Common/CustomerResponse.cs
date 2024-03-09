using Domain.ValueObjects;

namespace Customers.Common;

public record CustomerResponse(
Guid Id,
string FullName,
string Email,
string DuiNumber,
string PhoneNumber,
AddressResponse Address,
bool Active);

public record AddressResponse(
    string Departamento,
    string Municipio,
    string Distrito,
    string Direccion);