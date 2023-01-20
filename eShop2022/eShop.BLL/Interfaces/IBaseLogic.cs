using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Interfaces
{
    public interface IBaseLogic<T> where T : class
    {
        List<T> GetAll();
        T GetByGuid(Guid guid);
        T Insert(T entity);
        void Update(T entity);
        void Delete(Guid guid);
    }
}
