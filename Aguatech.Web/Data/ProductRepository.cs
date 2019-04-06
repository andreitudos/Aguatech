namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }
    }
}
