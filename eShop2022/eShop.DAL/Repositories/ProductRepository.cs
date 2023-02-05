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
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Product> results = _dbContext.Products
                .Include(x => x.Brand);
            return await results.ToListAsync(token);
        }

        //public IEnumerable<Product> GetAllActive()
        //{
        //    return _dbContext.Products
        //        .Where(x => x.IsHidden == false)
        //        .AsEnumerable();
        //}

        //public IEnumerable<Product> GetAllFeaturedProducts()
        //{
        //    return _dbContext.Products
        //        .Include(x => x.Brand)
        //        .Where(x => x.IsFeatured == true && x.IsActive == true)
        //        .AsEnumerable();
        //}

        //public IEnumerable<Product> GetAllNewProducts()
        //{
        //    return _dbContext.Products
        //         .Include(x => x.Brand)
        //         .Where(x => x.IsActive == true)
        //         .OrderByDescending(x => x.Id)
        //         .AsEnumerable();
        //}

        public async Task<Product> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Products
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(Product entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Products
                .AddAsync(entity, token);
        }

        public void Delete(Product entity, CancellationToken token)
        {
            _dbContext.Products
                .Remove(entity);
        }

        public void Update(Product entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Products
                .Update(entity);
        }
    }
}
