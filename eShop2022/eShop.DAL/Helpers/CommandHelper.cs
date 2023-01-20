using eShop.DAL.Entities;
using eShop.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Helpers
{
    public static class CommandHelper
    {
        public static void AddEntity(BaseEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            if (entity.Guid.IsNull())
            {
                entity.Guid = Guid.NewGuid();
            }
        }

        public static void UpdateEntity(BaseEntity entity)
        {
            entity.ModifiedOn = DateTime.Now;
        }
    }
}
