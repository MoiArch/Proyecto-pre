using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Update;

public record UpdateVehiculoCommand(
    Guid Id,
    string Plates, 
    string Brand, 
    string Model, 
    string Year, 
    string Price
   ) : IRequest<ErrorOr<Unit>>;