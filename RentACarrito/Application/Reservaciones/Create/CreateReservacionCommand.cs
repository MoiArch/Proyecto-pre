using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Create;

public record CreateReservationCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Date
) : IRequest<ErrorOr<Unit>>;