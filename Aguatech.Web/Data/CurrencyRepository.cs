namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;

    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        private readonly DataContext context;
        public CurrencyRepository(DataContext context) : base(context)
        {
        }
    }
}
