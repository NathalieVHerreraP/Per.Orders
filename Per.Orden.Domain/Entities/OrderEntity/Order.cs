
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Per.Order.Domain.Entities.OrderEntity;

public class Order
{
    [Key]
    [Column("order_id")]
    public int id { get; set; }
    [Column("user_id")]
    public Guid userId { get; set; }
    [Column("cart_id")]
    public int cartId { get; set; }
    [Column("customer_address")]
    public string customerAddress { get; set; } = string.Empty;
    [Column("payment_method")]
    public string paymentMethod { get; set; } = string.Empty;
    [Column("status")]
    public string status { get; set; } = string.Empty;
    [Column("total")]
    public decimal total { get; set; }
    [Column("discount")]
    public decimal? discount { get; set; }
    [Column("created_at")]
    public DateTime createdAt { get; set; }
    [Column("updated_at")]
    public DateTime updatedAt { get; set; }
    [Column("cancellation_date")]
    public DateTime? cancellationDate { get; set; }

}


