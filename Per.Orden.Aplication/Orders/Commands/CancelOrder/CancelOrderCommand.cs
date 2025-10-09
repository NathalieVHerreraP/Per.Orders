

using MediatR;
using Per.Order.Domain.Shared;

namespace Per.Order.Application.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(int orderId) : IRequest<Result<CancelOrderCommandResponse>>;

