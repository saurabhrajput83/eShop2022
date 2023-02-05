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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _dbContext;

        public InventoryRepository(AppDbContext dbContext)
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

        public void Insert(Inventory entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Inventories
                 .Add(entity);
        }

        public void Delete(Inventory entity)
        {
            _dbContext.Inventories
                 .Remove(entity);
        }

        public void Update(Inventory entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Inventories
                .Update(entity);
        }
    }
}
