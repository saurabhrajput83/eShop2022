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

        public void Insert(Review entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Reviews
                  .Add(entity);
        }

        public void Delete(Review entity)
        {
            _dbContext.Reviews
                .Remove(entity);
        }

        public void Update(Review entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Reviews
                .Update(entity);
        }
    }
}
