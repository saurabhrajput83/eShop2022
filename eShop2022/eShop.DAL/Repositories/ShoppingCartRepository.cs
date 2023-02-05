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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _dbContext;

        public ShoppingCartRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ShoppingCart>> GetAllAsync(CancellationToken token)
        {
            IQueryable<ShoppingCart> results = _dbContext.ShoppingCarts;
            return await results.ToListAsync(token);
        }

        public async Task<ShoppingCart> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.ShoppingCarts
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(ShoppingCart entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.ShoppingCarts
                 .AddAsync(entity, token);
        }

        public void Delete(ShoppingCart entity, CancellationToken token)
        {
            _dbContext.ShoppingCarts
                 .Remove(entity);
        }

        public void Update(ShoppingCart entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ShoppingCarts
                .Update(entity);
        }
    }
}
