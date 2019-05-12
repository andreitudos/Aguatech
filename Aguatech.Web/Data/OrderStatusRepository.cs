namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(DataContext context) : base(context)
        {
        }
    }
}
