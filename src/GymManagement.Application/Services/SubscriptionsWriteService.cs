namespace GymManagement.Application.Services;

internal class SubscriptionsWriteService : ISubscriptionsWriteService
{
    public Guid CreateSubscription(string subscriptionType, Guid adminId)
    {
        return Guid.NewGuid();
    }
}