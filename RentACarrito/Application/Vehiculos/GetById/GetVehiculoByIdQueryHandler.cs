using Domain.Vehiculos;
using ErrorOr;
using MediatR;
using Vehiculos.Common;

namespace Application.Vehiculos.GetById;


internal sealed class GetVehiculoByIdQueryHandler : IRequestHandler<GetVehiculoByIdQuery, ErrorOr<VehiculoResponse>>
{
    private readonly IVehiculoRepository _vehiculoRepository;

    public GetVehiculoByIdQueryHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository ?? throw new ArgumentNullException(nameof(vehiculoRepository));
    }

    public async Task<ErrorOr<VehiculoResponse>> Handle(GetVehiculoByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _vehiculoRepository.GetByIdAsync(new VehiculoId(query.Id)) is not Vehiculo vehiculo)
        {
            return Error.NotFound("Vehiculo.NotFound", "The customer with the provide Id was not found.");
        }

        return new VehiculoResponse(
            vehiculo.Id.Value, 
            vehiculo.Plates, 
            vehiculo.Brand,
            vehiculo.Model,
            vehiculo.Year,
            vehiculo.Price
          );
    }
}
