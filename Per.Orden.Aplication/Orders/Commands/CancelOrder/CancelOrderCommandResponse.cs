
namespace Per.Order.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandResponse
{
    public int id { get; set; }
    public DateTime? cancellationDate { get; set; }
    public string status { get; set; } = string.Empty;

}
