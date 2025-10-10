
namespace Per.Order.Domain.Entities.OrderEntity.Models;

public class CancelOrderModel
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? CancellationDate { get; set; }

}
