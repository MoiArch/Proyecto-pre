using FluentValidation;

namespace Application.Vehiculos.Update;

public class UpdateVehiculoCommandValidator : AbstractValidator<UpdateVehiculoCommand>
{
    public UpdateVehiculoCommandValidator()
    {
        RuleFor(r => r.Id)
           .NotEmpty();

        RuleFor(r => r.Plates)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Brand)
             .NotEmpty()
             .MaximumLength(50);

        RuleFor(r => r.Model)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Year)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Price)
            .NotEmpty()
            .MaximumLength(50);
    }
}