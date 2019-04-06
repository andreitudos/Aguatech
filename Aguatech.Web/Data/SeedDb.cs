namespace Aguatech.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Aguatech.Web.Data.Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.addProduct("Electrobomba de pistcina XKP900");
                this.addProduct("Corpo de bomba A17 TERMAR ");
                this.addProduct("Motor para bomba submerssivel 400V "+ this.random.Next(1,7) + "CV");
                await this.context.SaveChangesAsync();
            }
        }

        private void addProduct(string name)
        {
            this.context.Products.Add(new Product {
                Name = name,
                Price = this.random.Next(450),
                IsAvailable = true,
                Stock = this.random.Next(800)
            });
        }
    }
}
