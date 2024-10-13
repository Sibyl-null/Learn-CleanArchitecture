using ErrorOr;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Domain.Subscriptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            options.AddBehavior<IPipelineBehavior<CreateSubscriptionCommand, ErrorOr<Subscription>>,
                CreateSubscriptionCommandBehavior>();
        });
        
        return services;
    }
}