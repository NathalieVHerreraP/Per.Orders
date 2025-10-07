
using Microsoft.EntityFrameworkCore;
using OrderEntity = Per.Order.Domain.Entities.OrderEntity.Order;

namespace Per.Order.Infrastructure.Persistence.Context;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }
    public virtual DbSet<OrderEntity> Orders { get; set; }
}
