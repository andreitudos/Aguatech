namespace Aguatech.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
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

        public IQueryable GetByCategory(string category)
        {
            return this.context.Products.Where(c=>c.Category.Name==category);
        }
        public IQueryable GetByBarcode(string barcode)
        {
            return  this.context.Products.Where(b => b.Barcode == barcode);
        }
    }
}
