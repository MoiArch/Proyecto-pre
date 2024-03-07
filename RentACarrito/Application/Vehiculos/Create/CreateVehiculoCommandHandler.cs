using Domain.Primitives;
using Domain.Vehiculos;
using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Create;

public sealed class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, ErrorOr<Unit>>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository ?? throw new ArgumentNullException(nameof(vehiculoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<ErrorOr<Unit>> Handle(CreateVehiculoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var vehiculo = new Vehiculo(
            new VehiculoId(Guid.NewGuid()),
            command.Plates,
            command.Brand,
            command.Model,
            command.Year,
            command.Price
           );

            await _vehiculoRepository.Add(vehiculo);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateCustomer.Failure", ex.Message);
        }
    }
}