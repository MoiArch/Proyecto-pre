using Reservaciones.Common;
using ErrorOr;
using MediatR;
using Domain.Reservaciones;

namespace Application.Reservaciones.GetAll;

public record GetAllReservacionesQuery() : IRequest<ErrorOr<IReadOnlyList<ReservacionResponse>>>;