using Domain.Primitives;
using Domain.Vehiculos;
using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Delete;

internal sealed class DeleteVehiculoCommandHandler : IRequestHandler<DeleteVehiculoCommand, ErrorOr<Unit>>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository ?? throw new ArgumentNullException(nameof(vehiculoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteVehiculoCommand command, CancellationToken cancellationToken)
    {
        if (await _vehiculoRepository.GetByIdAsync(new VehiculoId(command.Id)) is not Vehiculo vehiculo)
        {
            return Error.NotFound("Vehiculo.NotFound", "The vehiculo with the provide Id was not found.");
        }

        _vehiculoRepository.Delete(vehiculo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}