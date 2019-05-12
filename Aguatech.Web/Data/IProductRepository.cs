namespace Aguatech.Web.Data
{
    using System.Linq;
    using Aguatech.Web.Data.Entities;
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUser();
        IQueryable GetByCategory(string category);
        IQueryable GetByBarcode(string barcode);
    }
}
