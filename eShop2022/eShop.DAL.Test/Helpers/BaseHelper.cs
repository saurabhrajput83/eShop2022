using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public abstract class BaseHelper<T> where T : class
    {
        internal void UpdateEntity(BaseEntity baseEntity)
        {
            baseEntity.CreatedOn = DateTime.Now;
            baseEntity.ModifiedOn = DateTime.Now;
            baseEntity.CreatedBy = "Test User";
            baseEntity.ModifiedBy = "Test User";
        }

        public abstract Task<T> InsertAsync(Guid guid);

        public abstract Task DeleteAsync(Guid guid);

        public abstract Task CleanUpAsync();

    }
}
