using Reservaciones.Common;
using Domain.Reservaciones;
using ErrorOr;
using MediatR;

namespace Application.Reservaciones.GetById;


internal sealed class GetReservacionByIdQueryHandler : IRequestHandler<GetReservacionByIdQuery, ErrorOr<ReservacionResponse>>
{
    private readonly IReservacionRepository _reservacionRepository;

    public GetReservacionByIdQueryHandler(IReservacionRepository reservacionRepository)
    {
        _reservacionRepository = reservacionRepository ?? throw new ArgumentNullException(nameof(reservacionRepository));
    }

    public async Task<ErrorOr<ReservacionResponse>> Handle(GetReservacionByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _reservacionRepository.GetByIdAsync(new ReservacionId(query.Id)) is not Reservacion reservacion)
        {
            return Error.NotFound("Reservacion.NotFound", "The reservation with the provide Id was not found.");
        }

        return new ReservacionResponse(
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
            );
    }
}