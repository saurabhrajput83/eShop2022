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
        private readonly AppDbContext _dbContext;

        public ProductVariationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductVariation>> GetAllAsync(CancellationToken token)
        {
            IQueryable<ProductVariation> results = _dbContext.ProductVariations
                .Include(x => x.Variation);
            return await results.ToListAsync(token);
        }

        public async Task<ProductVariation> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.ProductVariations
                  .Include(x => x.Variation)
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        //public IEnumerable<ProductVariation> GetByProductId(long productId)
        //{
        //    return _dbContext.ProductVariations
        //        .Include(x => x.Variation)
        //        .Where(x => x.ProductId == productId);
        //}

        public async Task InsertAsync(ProductVariation entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.ProductVariations
                 .AddAsync(entity, token);
        }

        public void Delete(ProductVariation entity, CancellationToken token)
        {
            _dbContext.ProductVariations
                  .Remove(entity);
        }

        public void Update(ProductVariation entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ProductVariations
                .Update(entity);
        }
    }
}
