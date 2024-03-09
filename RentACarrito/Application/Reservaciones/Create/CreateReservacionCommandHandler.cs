using Domain.Primitives;
using Domain.Reservaciones;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Create;

public sealed class CreateReservacionCommandHandler : IRequestHandler<CreateReservacionCommand, ErrorOr<Unit>>
{
    private readonly IReservacionRepository _reservacionRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateReservacionCommandHandler(IReservacionRepository reservacionRepository, IUnitOfWork unitOfWork)
    {
        _reservacionRepository = reservacionRepository ?? throw new ArgumentNullException(nameof(reservacionRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(CreateReservacionCommand command, CancellationToken cancellationToken)
    {
        try
        {
            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                return Error.Validation("Reservacion.PhoneNumber", "Phone Number Invalid");
            }

            var reservacion = new Reservacion(
                new ReservacionId(Guid.NewGuid()),
                command.Name,
                command.LastName,
                command.Email,
                phoneNumber,
                command.Date
            );

            _reservacionRepository.Add(reservacion);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateReservacion.Failure", ex.Message);
        }
    }
}