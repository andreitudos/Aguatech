namespace Aguatech.Web.Data
{
    using Entities;
    public class CustomerTypeRepository : GenericRepository<CustomerType>, ICustomerTypeRepository
    {
        private readonly DataContext context;
        public CustomerTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
