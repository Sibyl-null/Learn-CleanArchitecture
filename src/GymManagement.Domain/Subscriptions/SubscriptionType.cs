using Ardalis.SmartEnum;

namespace GymManagement.Domain.Subscriptions;

public class SubscriptionType : SmartEnum<SubscriptionType>
{
    public static readonly SubscriptionType Free = new(nameof(Free), 0);
    public static readonly SubscriptionType Starter = new(nameof(Starter), 0);
    public static readonly SubscriptionType Pro = new(nameof(Pro), 0);

    private SubscriptionType(string name, int value) : base(name, value)
    {
    }
}