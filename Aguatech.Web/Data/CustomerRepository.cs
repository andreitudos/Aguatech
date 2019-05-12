namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DataContext context;
        public CustomerRepository( DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
