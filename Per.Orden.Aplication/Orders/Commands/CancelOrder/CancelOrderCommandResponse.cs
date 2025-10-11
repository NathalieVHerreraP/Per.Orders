namespace Per.Order.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandResponse
{
    public int Id { get; set; }
    public DateTime? CancellationDate { get; set; }
    public string Status { get; set; } = string.Empty;

}
