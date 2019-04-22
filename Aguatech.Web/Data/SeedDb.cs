namespace Aguatech.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Aguatech.Web.Helpers;
    using Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("andreitudos@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Andrei",
                    LastName = "Tudos",
                    Email = "andreitudos@gmail.com",
                    UserName = "andreitudos@gmail.com",
                    PhoneNumber = "926310636"
                };

                //Adicionar utilizador
                var result = await this.userHelper.AddUserAsync(user, "123456");
                if(result!= IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder: ");
                }
            }

            //Category Seed
            if (!this.context.Categories.Any())
            {
                this.addCategory("Hidraulica", "Material hidraulico, tubagens, electrobombas");
                await this.context.SaveChangesAsync();
            }
            //Products Seed
            if (!this.context.Products.Any())
            {
                this.addProduct("Electrobomba de pistcina XKP900", user);
                this.addProduct("Corpo de bomba A17 TERMAR ", user);
                this.addProduct("Motor para bomba submerssivel 400V "+ this.random.Next(1,7) + "CV", user);
                await this.context.SaveChangesAsync();
            }

            //Brands seed
            if (!this.context.Marcas.Any())
            {
                this.addMarc("Pedrollo");
                await this.context.SaveChangesAsync();
            }
        }

        private void addMarc(string name)
        {
            
            this.context.Marcas.Add(new Marca {
                Name = name,
            });
        }

        private void addCategory(string name , string description)
        {

            this.context.Categories.Add(new Category
            {
                Name = name,
                Description = description
            });
        }

        private void addProduct(string name, User user)
        {
            this.context.Products.Add(new Product {
                Name = name,
                Price = this.random.Next(450),
                IsAvailable = true,
                Stock = this.random.Next(800),
                User = user
            });
        }
    }
}
