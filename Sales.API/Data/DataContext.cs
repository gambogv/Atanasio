using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entites;

namespace Sales.API.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ingreso> Ingresos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ingreso>().HasIndex(c => c.Id).IsUnique();
        }

    }
}
