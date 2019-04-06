namespace Aguatech.Web.Data
{
    using Aguatech.Web.Data.Entities;
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(DataContext context) : base(context)
        {

        }
    }
}
