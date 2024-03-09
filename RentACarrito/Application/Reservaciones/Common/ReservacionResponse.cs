using Domain.ValueObjects;

namespace Reservaciones.Common;

public record ReservacionResponse(
Guid Id,
string Name,
string LastName,
string Email,
string PhoneNumber,
string Date);

