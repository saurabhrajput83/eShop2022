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
        internal void UpdateDto(BaseFullView baseView)
        {
           
        }

        public abstract T Insert(Guid guid);

        public abstract void Delete(Guid guid);

        public abstract void CleanUp();

    }
}
