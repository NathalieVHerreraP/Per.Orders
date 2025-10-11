
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Per.Order.Domain.Entities.OrderEntity;

public class Order
{
    [Key]
    [Column("order_id")]
    public int Id { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }
    [Column("cart_id")]
    public int CartId { get; set; }
    [Column("customer_address")]
    public string CustomerAddress { get; set; } = string.Empty;
    [Column("payment_method")]
    public string PaymentMethod { get; set; } = string.Empty;
    [Column("status")]
    public string Status { get; set; } = string.Empty;
    [Column("total")]
    public decimal Total { get; set; }
    [Column("discount")]
    public decimal? Discount { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [Column("cancellation_date")]
    public DateTime? CancellationDate { get; set; }

}


