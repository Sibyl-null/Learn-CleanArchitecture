﻿using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

internal class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionQueryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await _subscriptionsRepository.GetByIdAsync(request.SubscriptionId);
        
        return subscription is null
            ? Error.NotFound(description: "Subscription not found")
            : subscription;
    }
}