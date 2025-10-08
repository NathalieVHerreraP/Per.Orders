
using MediatR;
using Per.Order.Domain.Entities.OrderEntity.Models;
using Per.Order.Domain.Entities.OrderEntity.Repositories;
using Per.Order.Domain.Shared;

namespace Per.Order.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler(IOrderRepository repository) : IRequestHandler<CancelOrderCommand, Result<CancelOrderCommandResponse>>
{
    private readonly IOrderRepository _repository = repository;
    public async Task<Result<CancelOrderCommandResponse>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.orderId <= 0)
        {
            return Result<CancelOrderCommandResponse>.Failure(400, "InvalidOrderId", "The order ID is not valid");
        }
        CancelOrderModel order;
        try
        {
            order = await _repository.CancelOrder(request.orderId, cancellationToken);
        }
        catch (Exception ex)
        {
            switch (ex.Message)
            {
                case "OrderNotFound":
                    return Result<CancelOrderCommandResponse>.Failure(404, "OrderNotFound", "The order was not found");
                case "OrderCanotBeCancel":
                    return Result<CancelOrderCommandResponse>.Failure(409, "OrderCanotBeCancel", "The order can't be canceled");
                case "TaskCancelled":
                    return Result<CancelOrderCommandResponse>.Failure(499, "TaskCancelled", "The operation was cancelled");
                default:
                    return Result<CancelOrderCommandResponse>.Failure(500, "ServerError", "An error occurred while processing the request");
            }
        }
        CancelOrderCommandResponse response = new()
        {
            id = order.id,
            cancellationDate = order.cancellationDate,
            status = order.status
        };


        return Result<CancelOrderCommandResponse>.Success(response);
    }
}
