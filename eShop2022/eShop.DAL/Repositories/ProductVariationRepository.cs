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

        public void Insert(ProductVariation entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.ProductVariations
                 .Add(entity);
        }

        public void Delete(ProductVariation entity)
        {
            _dbContext.ProductVariations
                  .Remove(entity);
        }

        public void Update(ProductVariation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ProductVariations
                .Update(entity);
        }
    }
}
