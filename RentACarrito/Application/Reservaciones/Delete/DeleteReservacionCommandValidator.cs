using FluentValidation;

namespace Application.Reservaciones.Delete;

public class DeleteReservacionCommandValidator : AbstractValidator<DeleteReservacionCommand>
{
    public DeleteReservacionCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}