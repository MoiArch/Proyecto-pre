using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Delete;

public record DeleteReservacionCommand(Guid Id) : IRequest<ErrorOr<Unit>>;