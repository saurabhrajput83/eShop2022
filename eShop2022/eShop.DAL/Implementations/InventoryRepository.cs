using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Implementations
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly eShopDbContext _dbContext;

        public InventoryRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _dbContext.Inventories
                .AsEnumerable();
        }

        public Inventory GetByGuid(Guid guid)
        {
            return _dbContext.Inventories
                .FirstOrDefault(p => p.Guid == guid);
        }

        public Inventory GetByProductId(long productId)
        {
            return _dbContext.Inventories
                .First(p => p.ProductId == productId);
        }

        public Inventory Insert(Inventory entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.Inventories
                  .Add(entity);
        }

        public Inventory Delete(Inventory entity)
        {
            return _dbContext.Inventories
                  .Remove(entity);
        }

        public void Update(Inventory entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Inventory>().AddOrUpdate(entity);
        }
    }
}
