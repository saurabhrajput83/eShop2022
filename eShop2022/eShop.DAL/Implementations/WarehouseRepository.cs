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
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly eShopDbContext _dbContext;

        public WarehouseRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _dbContext.Warehouses
                .AsEnumerable();
        }

        public Warehouse GetByGuid(Guid guid)
        {
            return _dbContext.Warehouses
                .FirstOrDefault(p => p.Guid == guid);
        }

        public Warehouse Insert(Warehouse entity)
        {
            return _dbContext.Warehouses
                .Add(entity);
        }

        public Warehouse Delete(Warehouse entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.Warehouses
                .Remove(entity);
        }

        public void Update(Warehouse entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Warehouse>().AddOrUpdate(entity);
        }
    }
}
