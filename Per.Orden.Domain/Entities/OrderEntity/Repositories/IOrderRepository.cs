using Per.Order.Domain.Entities.OrderEntity.Models;

namespace Per.Order.Domain.Entities.OrderEntity.Repositories;

public interface IOrderRepository
{
    public Task<CancelOrderModel> CancelOrder(int orderId, CancellationToken cancellationToken);
}
