using ErrorOr;
using MediatR;

namespace Application.Vehiculos.Delete;

public record DeleteVehiculoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;