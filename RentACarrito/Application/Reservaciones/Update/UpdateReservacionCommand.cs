using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Update;

public record UpdateReservacionCommand(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Date,
    string Plates, 
    string Brand,
    string Model, 
    string Year, 
    string Price
    ) : IRequest<ErrorOr<Unit>>;