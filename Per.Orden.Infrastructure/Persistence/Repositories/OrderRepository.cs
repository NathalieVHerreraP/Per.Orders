using Microsoft.EntityFrameworkCore;
using Per.Order.Domain.Entities.OrderEntity;
using Per.Order.Domain.Entities.OrderEntity.Models;
using Per.Order.Domain.Entities.OrderEntity.Repositories;
using Per.Order.Infrastructure.Persistence.Context;
using OrderEntity = Per.Order.Domain.Entities.OrderEntity.Order;

namespace Per.Order.Infrastructure.Persistence.Repositories;

internal class OrderRepository(AplicationDbContext context) : IOrderRepository
{
    public async Task<CancelOrderModel> CancelOrder(int orderId, CancellationToken cancellationToken)
    {
        OrderEntity order;
        try
        {
            order = await context.Orders.FirstOrDefaultAsync(x => x.id == orderId, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("TaskCancelled");
        }

        if (order is null)
        {
            throw new Exception("OrderNotFound");
        }

        if (String.Equals(order.status, "PENDING") || String.Equals(order.status, "CREATED"))
        {

            order.status = "CANCELLED";
            order.cancellationDate = DateTime.Now;
            order.updatedAt = DateTime.Now;
            context.Orders.Update(order);
            OrderStatusHistory statusHistory = new()
            {
                orderId = order.id,
                status = order.status,
                changedAt = order.updatedAt
            };
            try
            {
                await context.OrderStatusHistory.AddAsync(statusHistory, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
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
            id = order.id,
            cancellationDate = order.cancellationDate,
            status = order.status
        };

        return cancelOrder;
    }
}
