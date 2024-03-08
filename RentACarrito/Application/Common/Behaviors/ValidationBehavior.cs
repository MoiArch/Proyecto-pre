using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, Tresponse>: IPipelineBehavior<TRequest, Tresponse>
where TRequest : IRequest<Tresponse>
where Tresponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<Tresponse> Handle(TRequest request,
    RequestHandlerDelegate<Tresponse> next,
    CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.IsValid)
        {
            return await next();
        }

        var errors = validatorResult.Errors
        .ConvertAll(ValidationFailure => Error.Validation(
            ValidationFailure.PropertyName,
            ValidationFailure.ErrorMessage
        ));

        return (dynamic)errors;
    }
}
