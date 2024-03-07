using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Create;

public record CreateVehiculoCommand(
    string Plates,
    string Brand,
    string Model,
    string Year,
    string Price
) : IRequest<ErrorOr<Unit>>;