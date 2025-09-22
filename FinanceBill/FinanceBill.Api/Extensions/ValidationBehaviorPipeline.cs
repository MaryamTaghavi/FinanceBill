using FluentValidation;
using MediatR;

namespace FinanceBill.Api.Extensions;

public class ValidationBehaviorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviorPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var messages = failures.Select(f => f.ErrorMessage);
                var combinedMessage = string.Join("; ", messages);

                // پرتاب ValidationException با پیام قابل فهم
                throw new ValidationException($"Validation failed: {combinedMessage}", failures);
            }
        }

        return await next();
    }
}
