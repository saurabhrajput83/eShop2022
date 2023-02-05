using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Logics.Interfaces
{
    public interface IBaseLogic<TFullView, TMinimalView> where TFullView : class
    {
        List<TMinimalView> GetAll();
        TFullView GetByGuid(Guid guid);
        TFullView Insert(TFullView entity);
        void Update(TFullView entity);
        void Delete(Guid guid);
    }
}
