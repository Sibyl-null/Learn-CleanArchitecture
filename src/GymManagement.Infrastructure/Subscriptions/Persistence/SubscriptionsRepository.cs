using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

internal class SubscriptionsRepository : ISubscriptionsRepository
{
    private static readonly List<Subscription> _subscriptions = new();
    
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);
        return Task.CompletedTask;
    }
}