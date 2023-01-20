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
    public class VariationTypeRepository : IVariationTypeRepository
    {
        private readonly eShopDbContext _dbContext;

        public VariationTypeRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<VariationType> GetAll()
        {
            return _dbContext.VariationTypes
                .AsEnumerable();
        }

        public VariationType GetByGuid(Guid guid)
        {
            return _dbContext.VariationTypes
                .FirstOrDefault(p => p.Guid == guid);
        }

        public VariationType Insert(VariationType entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.VariationTypes
                  .Add(entity);
        }

        public VariationType Delete(VariationType entity)
        {
            return _dbContext.VariationTypes
                .Remove(entity);
        }

        public void Update(VariationType entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<VariationType>().AddOrUpdate(entity);
        }
    }
}
