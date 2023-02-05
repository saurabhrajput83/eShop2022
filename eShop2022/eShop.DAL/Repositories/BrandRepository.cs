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

        public async Task<List<Brand>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Brand> results = _dbContext.Brands;
            return await results.ToListAsync(token);

        }

        public async Task<Brand> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Brands
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }


        public async Task InsertAsync(Brand entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Brands
                 .AddAsync(entity, token);
        }

        public void Delete(Brand entity, CancellationToken token)
        {
            _dbContext.Brands
                 .Remove(entity);
        }

        public void Update(Brand entity, CancellationToken token)
        {
            _dbContext.Brands
              .Update(entity);
        }
    }
}
