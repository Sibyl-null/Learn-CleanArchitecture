using ErrorOr;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionsRepository
{
    Task AddSubscriptionAsync(Subscription subscription);
    Task<ErrorOr<Success>> DeleteSubscriptionAsync(Guid subscriptionId);
    Task<Subscription?> GetByIdAsync(Guid subscriptionId);
}