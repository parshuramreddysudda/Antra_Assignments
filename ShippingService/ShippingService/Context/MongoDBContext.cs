using Microsoft.EntityFrameworkCore;
using ShippingService.Entity;

namespace ShippingService.Context;

public class MongoDBContext:DbContext
{
    public MongoDBContext(DbContextOptions<MongoDBContext> options) : base(options)
    {

    }

    public DbSet<ShippingStatus> ShippingStatusSet { get; set; }
}