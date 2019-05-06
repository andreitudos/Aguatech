namespace Aguatech.Web.Data
{
    using Data.Entities;
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
