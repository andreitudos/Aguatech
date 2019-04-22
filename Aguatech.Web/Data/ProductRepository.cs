namespace Aguatech.Web.Data
{
    using System.Linq;
    using Aguatech.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext context;
        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUser()
        {
            return this.context.Products.Include(p => p.User);
        }
    }
}
