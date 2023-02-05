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

        public async Task<List<ProductImage>> GetAllAsync(CancellationToken token)
        {
            IQueryable<ProductImage> results = _dbContext.ProductImages;
            return await results.ToListAsync(token);
        }

        public async Task<ProductImage> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.ProductImages
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        //public IEnumerable<ProductImage> GetByProductId(long productId)
        //{
        //    return _dbContext.ProductImages
        //        .Where(x => x.ProductId == productId);
        //}

        public async Task InsertAsync(ProductImage entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.ProductImages
                  .AddAsync(entity, token);
        }

        public void Delete(ProductImage entity, CancellationToken token)
        {
            _dbContext.ProductImages
                 .Remove(entity);
        }

        public void Update(ProductImage entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.ProductImages
                .Update(entity);
        }

    }
}
