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

        public void Insert(SelectedItemVariation entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.SelectedItemVariations
                  .Add(entity);
        }

        public void Delete(SelectedItemVariation entity)
        {
            _dbContext.SelectedItemVariations
                    .Remove(entity);
        }

        public void Update(SelectedItemVariation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.SelectedItemVariations
                .Update(entity);
        }
    }
}
