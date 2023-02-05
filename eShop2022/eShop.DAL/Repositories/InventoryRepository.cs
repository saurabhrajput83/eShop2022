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

        public async Task<List<Inventory>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Inventory> results = _dbContext.Inventories;
            return await results.ToListAsync(token);
        }

        public async Task<Inventory> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Inventories
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        //public Inventory GetByProductId(long productId)
        //{
        //    return _dbContext.Inventories
        //        .First(p => p.ProductId == productId);
        //}

        public async Task InsertAsync(Inventory entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Inventories
                   .AddAsync(entity, token);
        }

        public void Delete(Inventory entity, CancellationToken token)
        {
            _dbContext.Inventories
                 .Remove(entity);
        }

        public void Update(Inventory entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Inventories
                .Update(entity);
        }
    }
}
