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
    public class SelectedItemVariationRepository : ISelectedItemVariationRepository
    {
        private readonly AppDbContext _dbContext;

        public SelectedItemVariationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SelectedItemVariation>> GetAllAsync(CancellationToken token)
        {
            IQueryable<SelectedItemVariation> results = _dbContext.SelectedItemVariations;
            return await results.ToListAsync(token);
        }

        public async Task<SelectedItemVariation> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.SelectedItemVariations
                .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(SelectedItemVariation entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.SelectedItemVariations
                  .AddAsync(entity, token);
        }

        public void Delete(SelectedItemVariation entity, CancellationToken token)
        {
            _dbContext.SelectedItemVariations
                    .Remove(entity);
        }

        public void Update(SelectedItemVariation entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.SelectedItemVariations
                .Update(entity);
        }
    }
}
