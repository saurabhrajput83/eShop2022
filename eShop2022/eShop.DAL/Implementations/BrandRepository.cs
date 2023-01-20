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
    public class BrandRepository : IBrandRepository
    {
        private readonly eShopDbContext _dbContext;

        public BrandRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _dbContext.Brands
                .AsEnumerable();
        }

        public Brand GetByGuid(Guid guid)
        {
            return _dbContext.Brands
                .FirstOrDefault(p => p.Guid == guid);
        }


        public Brand Insert(Brand entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.Brands
                .Add(entity);
        }

        public Brand Delete(Brand entity)
        {
            return _dbContext.Brands
                  .Remove(entity);
        }

        public void Update(Brand entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Brand>().AddOrUpdate(entity);
        }
    }
}
