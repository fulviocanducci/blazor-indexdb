using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.DataAccess
{
    public interface IRepository<T>
    {
        T Add(T model);
        T Update(T model);
        Task<T> FindAsync<TInput>(TInput id);
        Task DeleteAsync<TInput>(TInput id);
        Task<List<T>> AllAsync();
    }
}
