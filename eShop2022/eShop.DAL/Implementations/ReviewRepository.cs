using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace eShop.DAL.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly eShopDbContext _dbContext;

        public ReviewRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Review> GetAll()
        {
            return _dbContext.Reviews
                .AsEnumerable();
        }

        public IEnumerable<Review> GetByProductId(int productId)
        {
            return _dbContext.Reviews
                .Include(r => r.ProductId)
                .Where(r => r.ProductId == productId)
                .AsEnumerable();
        }

        public Review GetByGuid(Guid guid)
        {
            return _dbContext.Reviews
                .FirstOrDefault(r => r.Guid == guid);
        }

        public Review Insert(Review entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.Reviews
                   .Add(entity);
        }

        public Review Delete(Review entity)
        {
            return _dbContext.Reviews
                 .Remove(entity);
        }

        public void Update(Review entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Review>().AddOrUpdate(entity);
        }
    }
}
