using Application.Reservaciones.Delete;
using Domain.Customers;
using Domain.Primitives;
using Domain.Reservaciones;
using ErrorOr;
using MediatR;

namespace Application.Reservaciones.Delete;

internal sealed class DeleteReservacionCommandHandler : IRequestHandler<DeleteReservacionCommand, ErrorOr<Unit>>
{
    private readonly IReservacionRepository _reservacionRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteReservacionCommandHandler(IReservacionRepository reservacionRepository, IUnitOfWork unitOfWork)
    {
        _reservacionRepository = reservacionRepository ?? throw new ArgumentNullException(nameof(reservacionRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteReservacionCommand command, CancellationToken cancellationToken)
    {
        if (await _reservacionRepository.GetByIdAsync(new ReservacionId(command.Id)) is not Reservacion reservacion)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        _reservacionRepository.Delete(reservacion);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}