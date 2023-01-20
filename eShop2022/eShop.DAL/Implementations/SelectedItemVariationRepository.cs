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
    public class SelectedItemVariationRepository : ISelectedItemVariationRepository
    {
        private readonly eShopDbContext _dbContext;

        public SelectedItemVariationRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectedItemVariation> GetAll()
        {
            return _dbContext.SelectedItemVariations
                .AsEnumerable();
        }

        public SelectedItemVariation GetByGuid(Guid guid)
        {
            return _dbContext.SelectedItemVariations
                .FirstOrDefault(p => p.Guid == guid);
        }

        public SelectedItemVariation Insert(SelectedItemVariation entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.SelectedItemVariations
                   .Add(entity);
        }

        public SelectedItemVariation Delete(SelectedItemVariation entity)
        {
            return _dbContext.SelectedItemVariations
                     .Remove(entity);
        }

        public void Update(SelectedItemVariation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<SelectedItemVariation>().AddOrUpdate(entity);
        }
    }
}
