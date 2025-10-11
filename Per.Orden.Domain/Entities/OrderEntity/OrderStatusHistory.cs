
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Per.Order.Domain.Entities.OrderEntity;

public class OrderStatusHistory
{
    [Key]
    [Column("history_id")]
    public int Id { get; set; }
    [Column("order_id")]
    public int OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
    [Column("changed_at")]
    public DateTime ChangedAt { get; set; }
}

