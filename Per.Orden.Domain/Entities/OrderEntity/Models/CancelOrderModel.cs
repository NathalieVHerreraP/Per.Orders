
namespace Per.Order.Domain.Entities.OrderEntity.Models;

public class CancelOrderModel
{
    public int id { get; set; }
    public string status { get; set; } = string.Empty;
    public DateTime? cancellationDate { get; set; }

}
