using Microsoft.EntityFrameworkCore;
using Aguatech.Web.Models;
using Aguatech.Web.Data.Entities;
namespace Aguatech.Web.Data
{
    using System.Linq;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Formatar campo price
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");


            //Habilitar a cascade delete rule
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach(var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Aguatech.Web.Data.Entities.Brand> Brand { get; set; }

        public DbSet<Aguatech.Web.Data.Entities.Supplier> Supplier { get; set; }

        public DbSet<Aguatech.Web.Data.Entities.CustomerType> CustomerType { get; set; }

        public DbSet<Aguatech.Web.Data.Entities.OrderStatus> OrderStatus { get; set; }
            
    }
}
