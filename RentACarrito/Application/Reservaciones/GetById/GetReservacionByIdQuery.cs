using Reservaciones.Common;
using ErrorOr;
using MediatR;

namespace Application.Reservaciones.GetById;

public record GetReservacionByIdQuery(Guid Id) : IRequest<ErrorOr<ReservacionResponse>>;