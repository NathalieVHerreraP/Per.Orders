using Moq;
using Per.Order.Application.Orders.Commands.CancelOrder;
using Per.Order.Domain.Entities.OrderEntity.Repositories;
using CommandCancelOrder = Per.Order.Application.Orders.Commands.CancelOrder.CancelOrderCommand;

namespace Per.Order.Tests.Application.CommandHandlers.CancelOrderCommand;

public class CancelOrderCommandHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;

    public CancelOrderCommandHandlerTest()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
    }

    [Fact]
    public async Task Handler_Should_Cancel_Order ()
    {
        // Arrange
        var command = new CommandCancelOrder(1);

        var handler = new CancelOrderCommandHandler(_orderRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert

    }

    [Fact]
    public async Task Handler_Exception_Id_Not_Valid()
    {
        // Arrange

        // Act

        // Assert

    }

    [Fact]
    public async Task Handler_Exception_Cannot_Cancel_Order()
    {
        // Arrange

        // Act

        // Assert

    }

    [Fact]
    public async Task Handler_Exception_Order_Does_Not_Exist()
    {
        // Arrange

        // Act

        // Assert

    }
}
