using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Repositories.Interfaces;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Implementations.Repositories
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

        public void Insert(Warehouse entity)
        {
            _dbContext.Warehouses
               .Add(entity);
        }

        public void Delete(Warehouse entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Warehouses
               .Remove(entity);
        }

        public void Update(Warehouse entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Warehouses
                .Update(entity);
        }
    }
}
