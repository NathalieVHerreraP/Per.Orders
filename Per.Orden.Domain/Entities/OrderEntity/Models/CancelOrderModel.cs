namespace Per.Order.Domain.Entities.OrderEntity.Models;

public class CancelOrderModel
{
    public int id { get; set; }
    public DateTime? cancellationDate { get; set; }
    public string status { get; set; } = string.Empty;
}
