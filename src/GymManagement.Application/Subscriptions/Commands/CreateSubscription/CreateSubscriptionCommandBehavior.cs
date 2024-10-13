using ErrorOr;
using FluentValidation.Results;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandBehavior : IPipelineBehavior<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, 
        RequestHandlerDelegate<ErrorOr<Subscription>> next, 
        CancellationToken cancellationToken)
    {
        var validator = new CreateSubscriptionCommandValidator();
        ValidationResult result = await validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            return result.Errors
                .Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
                .ToList();
        }
        
        return await next();
    }
}