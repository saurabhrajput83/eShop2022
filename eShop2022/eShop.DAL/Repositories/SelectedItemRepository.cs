using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Repositories.Interfaces;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace eShop.DAL.Implementations.Repositories
{
    public class SelectedItemRepository : ISelectedItemRepository
    {
        private readonly AppDbContext _dbContext;

        public SelectedItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SelectedItem>> GetAllAsync(CancellationToken token)
        {
            IQueryable<SelectedItem> results = _dbContext.SelectedItems
                .Include(x => x.ShoppingCart)
                .Include(x => x.Product);
            return await results.ToListAsync(token);
        }

        //public IEnumerable<SelectedItem> GetByShoppingCartGuid(Guid shoppingCartGuid)
        //{
        //    return _dbContext.SelectedItems
        //        .Include(x => x.ShoppingCart)
        //        .Include(x => x.Product)
        //        .Where(x => x.ShoppingCart != null && x.ShoppingCart.Guid == shoppingCartGuid)
        //        .AsEnumerable();
        //}

        public async Task<SelectedItem> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.SelectedItems
                .Include(x => x.ShoppingCart)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(SelectedItem entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.SelectedItems
                  .AddAsync(entity, token);
        }

        public void Delete(SelectedItem entity, CancellationToken token)
        {
            _dbContext.SelectedItems
                   .Remove(entity);
        }

        public void Update(SelectedItem entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.SelectedItems
                .Update(entity);
        }
    }
}
