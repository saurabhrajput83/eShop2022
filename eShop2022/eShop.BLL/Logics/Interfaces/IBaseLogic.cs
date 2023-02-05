using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Logics.Interfaces
{
    public interface IBaseLogic<TFullView, TMinimalView> where TFullView : class
    {
        Task<List<TMinimalView>> GetAllAsync();
        Task<TFullView> GetByGuidAsync(Guid guid);
        Task<TFullView> InsertAsync(TFullView entity);
        Task UpdateAsync(TFullView entity);
        Task DeleteAsync(Guid guid);
    }
}
