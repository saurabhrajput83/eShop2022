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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductImage> GetAll()
        {
            return _dbContext.ProductImages
                .AsEnumerable();
        }

        public ProductImage GetByGuid(Guid guid)
        {
            return _dbContext.ProductImages
                .FirstOrDefault(p => p.Guid == guid);
        }

        public IEnumerable<ProductImage> GetByProductId(long productId)
        {
            return _dbContext.ProductImages
                .Where(x => x.ProductId == productId);
        }

        public void Insert(ProductImage entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.ProductImages
                  .Add(entity);
        }

        public void Delete(ProductImage entity)
        {
            _dbContext.ProductImages
                 .Remove(entity);
        }

        public void Update(ProductImage entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ProductImages
                .Update(entity);
        }

    }
}
