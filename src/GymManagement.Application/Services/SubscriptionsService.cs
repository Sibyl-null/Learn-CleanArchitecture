namespace GymManagement.Application.Services;

internal class SubscriptionsService : ISubscriptionsService
{
    public Guid CreateSubscription(string subscriptionType, Guid adminId)
    {
        return Guid.NewGuid();
    }
}