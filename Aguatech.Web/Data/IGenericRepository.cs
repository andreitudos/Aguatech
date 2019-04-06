namespace Aguatech.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : class
    {
        //Returnar uma lista de varios objetos
        IQueryable<T> GetAll();

        //Return um determinado objeto T
        Task<T> GetByIdAsync(int id);

        //Cria um determinado objeto T
        Task CreateAsync(T entity);

        //Actualiza um determinado objeto T
        Task UpdateAsync(T entity);

        //Apaga um determinado objeto T
        Task DeleteAsync(T entity);

        //Verifica se um determinado objeto T exista
        Task<bool> ExistsAsync(int id);

    }
}
