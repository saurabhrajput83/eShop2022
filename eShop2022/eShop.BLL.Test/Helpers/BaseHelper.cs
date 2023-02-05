using eShop.BLL.Dtos;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public abstract class BaseHelper<T> where T : class
    {
        public void UpdateView(BaseFullView baseView)
        {

        }

        public abstract Task<T> InsertAsync(Guid guid);

        public abstract Task DeleteAsync(Guid guid);

        public abstract Task CleanUpAsync();

    }
}
