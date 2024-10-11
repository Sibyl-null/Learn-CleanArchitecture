using ErrorOr;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using GymManagement.Domain.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISender _mediator;

    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(
            request.SubscriptionType.ToString(),
            request.AdminId);

        ErrorOr<Subscription> result = await _mediator.Send(command);

        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            error => Problem());
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);
        ErrorOr<Subscription> result = await _mediator.Send(query);

        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
            error => Problem());
    }
}