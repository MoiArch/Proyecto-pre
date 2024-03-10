using FluentValidation;

namespace Application.Reservaciones.Create;

public class CreateReservacionCommandValidator : AbstractValidator<CreateReservacionCommand>
{
    public CreateReservacionCommandValidator()
    {
        RuleFor(r => r.Name)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Name");

        RuleFor(r => r.LastName)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Last Name");

        RuleFor(r => r.Email)
        .NotEmpty()
        .EmailAddress()
        .MaximumLength(255)
        .WithName("Email");

        RuleFor(r => r.PhoneNumber)
        .NotEmpty()
        .MaximumLength(9)
        .WithName("Phone Number");

        RuleFor(r => r.Date)
        .NotEmpty()
        .MaximumLength(50)
        .WithName("Date");

        RuleFor(r => r.Plates)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Plates");

        RuleFor(r => r.Brand)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Brand");

        RuleFor(r => r.Model)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Model");

        RuleFor(r => r.Year)
        .NotEmpty()
        .MaximumLength(255)
        .WithName("Year");

        RuleFor(r => r.Price)
        .NotEmpty()
        .MaximumLength(255)
        .WithName("Price");
    }
}