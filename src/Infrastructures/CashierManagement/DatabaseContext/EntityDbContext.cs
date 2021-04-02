using Microsoft.EntityFrameworkCore;

namespace CashierManagementInfractureLayer.DatabaseContext
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
