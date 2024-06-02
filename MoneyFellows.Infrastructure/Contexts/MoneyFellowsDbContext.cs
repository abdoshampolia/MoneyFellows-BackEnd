using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyFellows.Core.Entities;
using MoneyFellows.Infrastructure.Contexts.Seed;

namespace MoneyFellows.Infrastructure.Contexts
{
    public class MoneyFellowsDbContext : IdentityDbContext<User, Role, Guid>
    {
        public MoneyFellowsDbContext(DbContextOptions<MoneyFellowsDbContext> options) : base(options)
        { }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductsOrder { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RoleSeed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
