using FluentValidation;

namespace Application.Customers.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
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

        RuleFor(r => r.DuiNumber)
        .NotEmpty()
        .MaximumLength(10)
        .WithName("DUI Number");

        RuleFor(r => r.Departamento)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Departamento");

        RuleFor(r => r.Municipio)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Municipio");

        RuleFor(r => r.Distrito)
        .NotEmpty()
        .MaximumLength(40)
        .WithName("Distrito");

        RuleFor(r => r.Direccion)
        .NotEmpty()
        .MaximumLength(255)
        .WithName("Direccion");

    }
}