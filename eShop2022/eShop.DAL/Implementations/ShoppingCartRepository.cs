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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly eShopDbContext _dbContext;

        public ShoppingCartRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCarts.AsEnumerable();
        }

        public ShoppingCart GetByGuid(Guid guid)
        {
            return _dbContext.ShoppingCarts
                .FirstOrDefault(p => p.Guid == guid);
        }

        public ShoppingCart Insert(ShoppingCart entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.ShoppingCarts
                  .Add(entity);
        }

        public ShoppingCart Delete(ShoppingCart entity)
        {
            return _dbContext.ShoppingCarts
                  .Remove(entity);
        }

        public void Update(ShoppingCart entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<ShoppingCart>().AddOrUpdate(entity);
        }
    }
}
