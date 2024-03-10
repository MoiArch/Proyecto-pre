using Reservaciones.Common;
using ErrorOr;
using MediatR;
using Domain.Reservaciones;
using Application.Reservaciones.GetAll;

namespace Application.Customers.GetAll;


internal sealed class GetAllReservacionesQueryHandler : IRequestHandler<GetAllReservacionesQuery, ErrorOr<IReadOnlyList<ReservacionResponse>>>
{
    private readonly IReservacionRepository _reservacionRepository;

    public GetAllReservacionesQueryHandler(IReservacionRepository reservacionRepository)
    {
        _reservacionRepository = reservacionRepository ?? throw new ArgumentNullException(nameof(reservacionRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ReservacionResponse>>> Handle(GetAllReservacionesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Reservacion> reservacion = (IReadOnlyList<Reservacion>)await _reservacionRepository.GetAll();

        return reservacion.Select(reservacion => new ReservacionResponse(
                reservacion.Id.Value,
                reservacion.Name,
                reservacion.LastName,
                reservacion.Email,
                reservacion.PhoneNumber.Value,
                reservacion.Date,
                new VehicleResponse(reservacion.Vehicle.Plates,
                    reservacion.Vehicle.Brand,
                    reservacion.Vehicle.Model,
                    reservacion.Vehicle.Year,
                    reservacion.Vehicle.Price)
            )).ToList();
    }
}