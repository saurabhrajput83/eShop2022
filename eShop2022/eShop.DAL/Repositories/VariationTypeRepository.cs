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
    public class VariationTypeRepository : IVariationTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public VariationTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VariationType>> GetAllAsync(CancellationToken token)
        {
            IQueryable<VariationType> results = _dbContext.VariationTypes;
            return await results.ToListAsync(token);
        }

        public async Task<VariationType> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.VariationTypes
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(VariationType entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.VariationTypes
                 .AddAsync(entity, token);
        }

        public void Delete(VariationType entity, CancellationToken token)
        {
            _dbContext.VariationTypes
               .Remove(entity);
        }

        public void Update(VariationType entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.VariationTypes
                .Update(entity);
        }
    }
}
