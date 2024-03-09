using FluentValidation;

namespace Application.Vehiculos.Delete;

public class DeleteVehiculoCommandValidator : AbstractValidator<DeleteVehiculoCommand>
{
    public DeleteVehiculoCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}