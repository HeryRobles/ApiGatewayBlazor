using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGatewayBlazor.SqlServer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .Property(p => p.ValorUnitario)
                .HasColumnType("decimal(18, 2)"); // Ajusta la precisión y la escala según tus necesidades

            modelBuilder.Entity<Venta>()
                .Property(v => v.TotalVenta)
                .HasColumnType("decimal(18, 2)"); // Ajusta la precisión y la escala según tus necesidades
        }
    }
    
}
