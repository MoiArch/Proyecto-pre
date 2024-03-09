using Domain.Primitives;
using Domain.Vehiculos;
using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Update;

internal sealed class UpdateVehiculoCommandHandler : IRequestHandler<UpdateVehiculoCommand, ErrorOr<Unit>>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository ?? throw new ArgumentNullException(nameof(vehiculoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateVehiculoCommand command, CancellationToken cancellationToken)
    {
        if (!await _vehiculoRepository.ExistsAsync(new VehiculoId(command.Id)))
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

       
        Vehiculo vehiculo = Vehiculo.UpdateVehiculo(command.Id, 
            command.Plates,
            command.Brand,
            command.Model,
            command.Year,
            command.Price
           );

        _vehiculoRepository.Update(vehiculo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}