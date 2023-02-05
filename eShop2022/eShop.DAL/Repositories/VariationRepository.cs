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
    public class VariationRepository : IVariationRepository
    {
        private readonly AppDbContext _dbContext;

        public VariationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Variation>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Variation> results = _dbContext.Variations
                .Include(v => v.VariationType);
            return await results.ToListAsync(token);
        }


        public async Task<Variation> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Variations
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(Variation entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Variations
                  .AddAsync(entity, token);
        }

        public void Delete(Variation entity, CancellationToken token)
        {
            _dbContext.Variations
                  .Remove(entity);
        }

        public void Update(Variation entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Variations
                .Update(entity);
        }
    }
}
