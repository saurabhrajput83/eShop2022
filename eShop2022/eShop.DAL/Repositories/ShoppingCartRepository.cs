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

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCarts.AsEnumerable();
        }

        public ShoppingCart GetByGuid(Guid guid)
        {
            return _dbContext.ShoppingCarts
                .FirstOrDefault(p => p.Guid == guid);
        }

        public void Insert(ShoppingCart entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.ShoppingCarts
                 .Add(entity);
        }

        public void Delete(ShoppingCart entity)
        {
            _dbContext.ShoppingCarts
                 .Remove(entity);
        }

        public void Update(ShoppingCart entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ShoppingCarts
                .Update(entity);
        }
    }
}
