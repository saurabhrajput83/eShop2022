using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task<T> GetByGuidAsync(Guid guid, CancellationToken token);
        Task InsertAsync(T entity, CancellationToken token);
        void Update(T entity, CancellationToken token);
        void Delete(T entity, CancellationToken token);

    }
}
