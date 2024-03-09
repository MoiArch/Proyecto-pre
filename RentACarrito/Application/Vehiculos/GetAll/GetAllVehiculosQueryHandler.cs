
using Domain.Vehiculos;
using ErrorOr;
using MediatR;
using Vehiculos.Common;

namespace Application.Vehiculos.GetAll;


internal sealed class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosQuery, ErrorOr<IReadOnlyList<VehiculoResponse>>>
{
    private readonly IVehiculoRepository _vehiculoRepository;

    public GetAllVehiculosQueryHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository ?? throw new ArgumentNullException(nameof(vehiculoRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<VehiculoResponse>>> Handle(GetAllVehiculosQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Vehiculo> vehiculos = await _vehiculoRepository.GetAll();

        return vehiculos.Select(vehiculo => new VehiculoResponse(
                vehiculo.Id.Value,
                vehiculo.Plates,
                vehiculo.Brand,
                vehiculo.Model,
                vehiculo.Year,
                vehiculo.Price
            )).ToList();
    }
}