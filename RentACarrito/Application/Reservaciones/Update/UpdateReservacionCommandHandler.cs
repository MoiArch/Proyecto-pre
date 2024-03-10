using Domain.Reservaciones;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Update;

internal sealed class UpdateReservacionCommandHandler : IRequestHandler<UpdateReservacionCommand, ErrorOr<Unit>>
{
    private readonly IReservacionRepository _reservacionRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateReservacionCommandHandler(IReservacionRepository reservacionRepository, IUnitOfWork unitOfWork)
    {
        _reservacionRepository = reservacionRepository ?? throw new ArgumentNullException(nameof(reservacionRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateReservacionCommand command, CancellationToken cancellationToken)
    {
        if (!await _reservacionRepository.ExistsAsync(new ReservacionId(command.Id)))
        {
            return Error.NotFound("Reservacion.NotFound", "The reservation with the provide Id was not found.");
        }

        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
        }
         if (Vehicle.Create(command.Plates, command.Brand, command.Model, command.Year, command.Price) is not Vehicle vehicle)
            {
                return Error.Validation("Reservacion.Vehicle", "Vehicle Invalid");
            }


        Reservacion reservacion = Reservacion.UpdateReservacion(
            command.Id, 
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            command.Date,
            vehicle);

         _reservacionRepository.Update(reservacion);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}