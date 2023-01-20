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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly eShopDbContext _dbContext;

        public ProductImageRepository(eShopDbContext dbContext)
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

        public ProductImage Insert(ProductImage entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.ProductImages
                   .Add(entity);
        }

        public ProductImage Delete(ProductImage entity)
        {
            return _dbContext.ProductImages
                  .Remove(entity);
        }

        public void Update(ProductImage entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<ProductImage>().AddOrUpdate(entity);
        }

    }
}
