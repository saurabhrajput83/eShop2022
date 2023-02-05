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

        public void Insert(VariationType entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.VariationTypes
                 .Add(entity);
        }

        public void Delete(VariationType entity)
        {
            _dbContext.VariationTypes
               .Remove(entity);
        }

        public void Update(VariationType entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.VariationTypes
                .Update(entity);
        }
    }
}
