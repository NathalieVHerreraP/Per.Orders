
using Microsoft.EntityFrameworkCore;
using Per.Order.Domain.Entities.OrderEntity;
using OrderEntity = Per.Order.Domain.Entities.OrderEntity.Order;

namespace Per.Order.Infrastructure.Persistence.Context;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }
    public virtual DbSet<OrderEntity> Orders { get; set; }
    public virtual DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
}
