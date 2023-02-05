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
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _dbContext;

        public BrandRepository(AppDbContext dbContext)
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


        public void Insert(Brand entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Brands
               .Add(entity);
        }

        public void Delete(Brand entity)
        {
            _dbContext.Brands
                 .Remove(entity);
        }

        public void Update(Brand entity)
        {
            _dbContext.Brands
                .Update(entity);
        }
    }
}
