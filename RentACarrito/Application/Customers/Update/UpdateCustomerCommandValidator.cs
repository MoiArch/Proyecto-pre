using FluentValidation;

namespace Application.Customers.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
         RuleFor(r => r.Id)
            .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(50); 

        RuleFor(r => r.LastName)
             .NotEmpty()
             .MaximumLength(50)
             .WithName("Last Name");

        RuleFor(r => r.Email)
             .NotEmpty()
             .EmailAddress()
             .MaximumLength(255);

       RuleFor(r => r.DuiNumber)
             .NotEmpty()
             .MaximumLength(10)
             .WithName("Phone Number");

        RuleFor(r => r.PhoneNumber)
             .NotEmpty()
             .MaximumLength(9)
             .WithName("Phone Number");

        RuleFor(r => r.Departamento)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Municipio)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("Municipio");

        RuleFor(r => r.Distrito)
            .MaximumLength(20)
            .WithName("Distrito");

        RuleFor(r => r.Direccion)
            .NotEmpty()
            .MaximumLength(40)
            .WithName("Direccion");

        RuleFor(r => r.Active)
            .NotNull();
    }
}