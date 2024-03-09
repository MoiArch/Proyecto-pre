using ErrorOr;
using MediatR;
using Vehiculos.Common;

namespace Application.Vehiculos.GetById;

public record GetVehiculoByIdQuery(Guid Id) : IRequest<ErrorOr<VehiculoResponse>>;