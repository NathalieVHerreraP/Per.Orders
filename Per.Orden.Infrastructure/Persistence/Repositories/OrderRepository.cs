using Microsoft.EntityFrameworkCore;
using Per.Order.Domain.Entities.OrderEntity;
using Per.Order.Domain.Entities.OrderEntity.Models;
using Per.Order.Domain.Entities.OrderEntity.Repositories;
using Per.Order.Infrastructure.Persistence.Context;
using OrderEntity = Per.Order.Domain.Entities.OrderEntity.Order;

namespace Per.Order.Infrastructure.Persistence.Repositories;

internal class OrderRepository(AplicationDbContext context) : IOrderRepository
{
    public async Task<CancelOrderModel> CancelOrder(OrderEntity order, CancellationToken cancellationToken)
    {

        if (String.Equals(order.Status, "PENDING") || String.Equals(order.Status, "CREATED"))
        {

            order.Status = "CANCELLED";
            order.CancellationDate = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            context.Orders.Update(order);
            OrderStatusHistory statusHistory = new()
            {
                OrderId = order.Id,
                Status = order.Status,
                ChangedAt = order.UpdatedAt
            };
            try
            {
                await context.OrderStatusHistory.AddAsync(statusHistory, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw new Exception("TaskCancelled");
            }
            

        }
        else
        {
            throw new Exception("OrderCanotBeCancel");
        }
        CancelOrderModel cancelOrder = new()
        {
            Id = order.Id,
            CancellationDate = order.CancellationDate,
            Status = order.Status
        };

        return cancelOrder;
    }

    public async Task<OrderEntity> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        OrderEntity? order;
        try
        {
            order = await context.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);
        }
        catch
        {
            throw new Exception("TaskCancelled");
        }

        if (order is null)
        {
            throw new Exception("OrderNotFound");
        }

        return order;

    }
}
