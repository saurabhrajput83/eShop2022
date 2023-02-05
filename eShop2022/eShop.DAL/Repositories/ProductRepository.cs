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
    public class ProductRepository : IProductRepository
    {
        private readonly eShopDbContext _dbContext;

        public ProductRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products
                .Include(x => x.Brand)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetAllActive()
        {
            return _dbContext.Products
                .Where(x => x.IsHidden == false)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetAllFeaturedProducts()
        {
            return _dbContext.Products
                .Include(x => x.Brand)
                .Where(x => x.IsFeatured == true && x.IsActive == true)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetAllNewProducts()
        {
            return _dbContext.Products
                 .Include(x => x.Brand)
                 .Where(x => x.IsActive == true)
                 .OrderByDescending(x => x.Id)
                 .AsEnumerable();
        }

        public Product GetByGuid(Guid guid)
        {
            return _dbContext.Products
                .Include(x => x.Brand)
                .FirstOrDefault(p => p.Guid == guid);
        }

        public void Insert(Product entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Products
                .Add(entity);
        }

        public void Delete(Product entity)
        {
            _dbContext.Products
                .Remove(entity);
        }

        public void Update(Product entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Products
                .Update(entity);
        }
    }
}
