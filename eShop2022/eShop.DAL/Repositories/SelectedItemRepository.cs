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
        private readonly eShopDbContext _dbContext;

        public SelectedItemRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectedItem> GetAll()
        {
            return _dbContext.SelectedItems.AsEnumerable();
        }

        public IEnumerable<SelectedItem> GetByShoppingCartGuid(Guid shoppingCartGuid)
        {
            return _dbContext.SelectedItems
                .Include(x => x.ShoppingCart)
                .Include(x => x.Product)
                .Where(x => x.ShoppingCart != null && x.ShoppingCart.Guid == shoppingCartGuid)
                .AsEnumerable();
        }

        public SelectedItem GetByGuid(Guid guid)
        {
            return _dbContext.SelectedItems
                .Include(x => x.ShoppingCart)
                .Include(x => x.Product)
                .FirstOrDefault(p => p.Guid == guid);
        }

        public void Insert(SelectedItem entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.SelectedItems
                  .Add(entity);
        }

        public void Delete(SelectedItem entity)
        {
            _dbContext.SelectedItems
                   .Remove(entity);
        }

        public void Update(SelectedItem entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.SelectedItems
                .Update(entity);
        }
    }
}
