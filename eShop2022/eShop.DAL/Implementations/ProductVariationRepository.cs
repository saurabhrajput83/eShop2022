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
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly eShopDbContext _dbContext;

        public ProductVariationRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductVariation> GetAll()
        {
            return _dbContext.ProductVariations
                .Include(x => x.Variation)
                .AsEnumerable();
        }

        public ProductVariation GetByGuid(Guid guid)
        {
            return _dbContext.ProductVariations
                .FirstOrDefault(p => p.Guid == guid);
        }

        public IEnumerable<ProductVariation> GetByProductId(long productId)
        {
            return _dbContext.ProductVariations
                .Include(x => x.Variation)
                .Where(x => x.ProductId == productId);
        }

        public ProductVariation Insert(ProductVariation entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.ProductVariations
                  .Add(entity);
        }

        public ProductVariation Delete(ProductVariation entity)
        {
            return _dbContext.ProductVariations
                   .Remove(entity);
        }

        public void Update(ProductVariation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<ProductVariation>().AddOrUpdate(entity);
        }
    }
}
