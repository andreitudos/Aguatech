namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;

    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DataContext context;
        public BrandRepository(DataContext context) : base(context)
        {
        }
    }
}
