using Moq;
using OrderEntity = Per.Order.Domain.Entities.OrderEntity.Order;
using Per.Order.Domain.Entities.OrderEntity.Repositories;

namespace Per.Order.Tests.Application.CommandHandlers.CancelOrderCommand;

public class MockOrdersRepository
{
    public static Mock<IOrderRepository> CancelOrderRepository()
    {
        var orders = new List<OrderEntity>
        {
            new OrderEntity
            {
                id = 1,
                userId = Guid.NewGuid(),
                cartId = 1,
                customerAddress = "123 Main St",
                paymentMethod = "CREDIT_CARD",
                status = "PENDING",
                createdAt = DateTime.Now.AddDays(-1),
                updatedAt = DateTime.Now.AddDays(-1),
                cancellationDate = null,
                discount = 0.00m,
                total = 100.00m
            },
            new OrderEntity
            {
                id = 2,
                userId = Guid.NewGuid(),
                cartId = 1,
                customerAddress = "123 Main St",
                paymentMethod = "CREDIT_CARD",
                status = "CANCELLED",
                createdAt = DateTime.Now.AddDays(-1),
                updatedAt = DateTime.Now.AddDays(-1),
                cancellationDate = DateTime.Now.AddDays(-1),
                discount = 0.00m,
                total = 100.00m
            }
        };
        var mockRepo = new Mock<IOrderRepository>();
        return null;
    }


}
