namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }
    }
}
