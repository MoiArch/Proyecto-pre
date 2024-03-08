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
    }
}