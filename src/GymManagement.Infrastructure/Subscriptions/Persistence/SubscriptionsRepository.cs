using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

internal class SubscriptionsRepository : ISubscriptionsRepository
{
    private readonly GymManagerDbContext _dbContext;

    public SubscriptionsRepository(GymManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _dbContext.Subscriptions.AddAsync(subscription);
    }

    public async Task<ErrorOr<Success>> DeleteSubscriptionAsync(Guid subscriptionId)
    {
        Subscription? subscription = await _dbContext.Subscriptions.FindAsync(subscriptionId);
        if (subscription == null)
            return Error.NotFound("Subscription not found");
        
        _dbContext.Subscriptions.Remove(subscription);
        return new Success();
    }

    public async Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        return await _dbContext.Subscriptions.FindAsync(subscriptionId);
    }
}