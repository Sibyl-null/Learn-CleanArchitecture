using MediatR;
using ErrorOr;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

internal class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Guid>>
{
    public Task<ErrorOr<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult<ErrorOr<Guid>>(Guid.NewGuid());
    }
}