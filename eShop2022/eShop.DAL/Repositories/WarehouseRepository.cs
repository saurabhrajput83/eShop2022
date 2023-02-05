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
        private readonly AppDbContext _dbContext;

        public WarehouseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Warehouse>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Warehouse> results = _dbContext.Warehouses;
            return await results.ToListAsync(token);
        }

        public async Task<Warehouse> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Warehouses
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(Warehouse entity, CancellationToken token)
        {
            await _dbContext.Warehouses
               .AddAsync(entity, token);
        }

        public void Delete(Warehouse entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Warehouses
               .Remove(entity);
        }

        public void Update(Warehouse entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Warehouses
                .Update(entity);
        }
    }
}
