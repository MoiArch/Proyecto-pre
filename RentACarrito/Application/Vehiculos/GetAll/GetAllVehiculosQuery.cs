using ErrorOr;
using MediatR;
using Vehiculos.Common;

namespace Application.Vehiculos.GetAll;

public record GetAllVehiculosQuery() : IRequest<ErrorOr<IReadOnlyList<VehiculoResponse>>>;