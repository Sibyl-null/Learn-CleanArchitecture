using FluentValidation;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(x => x.SubscriptionType.Value)
            .NotEqual(SubscriptionType.Free.Value);
    }
}