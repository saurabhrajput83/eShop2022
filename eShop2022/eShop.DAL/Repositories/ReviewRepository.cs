using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Repositories.Interfaces;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace eShop.DAL.Implementations.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Review> results = _dbContext.Reviews;
            return await results.ToListAsync(token);
        }

        //public IEnumerable<Review> GetByProductId(int productId)
        //{
        //    return _dbContext.Reviews
        //        .Include(r => r.ProductId)
        //        .Where(r => r.ProductId == productId)
        //        .AsEnumerable();
        //}

        public async Task<Review> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Reviews
                .FirstOrDefaultAsync(r => r.Guid == guid, token);
        }

        public async Task InsertAsync(Review entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Reviews
                  .AddAsync(entity, token);
        }

        public void Delete(Review entity, CancellationToken token)
        {
            _dbContext.Reviews
                .Remove(entity);
        }

        public void Update(Review entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Reviews
                .Update(entity);
        }
    }
}
