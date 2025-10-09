
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Per.Order.Domain.Entities.OrderEntity;

public class OrderStatusHistory
{
    [Key]
    [Column("history_id")]
    public int id { get; set; }
    [Column("order_id")]
    public int orderId { get; set; }
    [Column("status")]
    public string status { get; set; } = string.Empty;
    [Column("changed_at")]
    public DateTime changedAt { get; set; }

}

