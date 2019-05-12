namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    public class ProductOrderRepository : GenericRepository<ProductOrder>, IProductOrderReposotory
    {
        public ProductOrderRepository(DataContext context) : base(context)
        {
        }
    }
}
