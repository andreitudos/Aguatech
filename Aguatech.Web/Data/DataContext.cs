namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
