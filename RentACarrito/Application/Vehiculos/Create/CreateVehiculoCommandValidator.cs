using FluentValidation;

namespace Application.Vehiculos.Create;

public class CreateVehiculoCommandValidator : AbstractValidator<CreateVehiculoCommand>
{
    public CreateVehiculoCommandValidator()
    {
        RuleFor(r => r.Plates)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Plates");

        RuleFor(r => r.Brand)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Brand name");

        RuleFor(r => r.Model)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Model Name");

        RuleFor(r => r.Year)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Year");

        RuleFor(r => r.Price)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Price");

    }
}