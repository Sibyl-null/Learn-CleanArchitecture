using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, ErrorOr<Success>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public DeleteSubscriptionCommandHandler(IUnitOfWork unitOfWork, ISubscriptionsRepository subscriptionsRepository)
    {
        _unitOfWork = unitOfWork;
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        ErrorOr<Success> result = await _subscriptionsRepository.DeleteSubscriptionAsync(request.SubscriptionId);
        await _unitOfWork.CommitChangesAsync();
        return result;
    }
}