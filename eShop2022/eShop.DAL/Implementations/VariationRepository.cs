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
    public class VariationRepository : IVariationRepository
    {
        private readonly eShopDbContext _dbContext;

        public VariationRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Variation> GetAll()
        {
            return _dbContext.Variations
                .Include(v => v.VariationType)
                .AsEnumerable();
        }

        public Variation GetByGuid(Guid guid)
        {
            return _dbContext.Variations
                .FirstOrDefault(p => p.Guid == guid);
        }

        public Variation Insert(Variation entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.Variations
                   .Add(entity);
        }

        public Variation Delete(Variation entity)
        {
            return _dbContext.Variations
                   .Remove(entity);
        }

        public void Update(Variation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Variation>().AddOrUpdate(entity);
        }
    }
}
