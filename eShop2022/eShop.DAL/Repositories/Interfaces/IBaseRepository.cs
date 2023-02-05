using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByGuid(Guid guid);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
