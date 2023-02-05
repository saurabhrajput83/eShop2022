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

        public void Insert(Variation entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Variations
                  .Add(entity);
        }

        public void Delete(Variation entity)
        {
            _dbContext.Variations
                  .Remove(entity);
        }

        public void Update(Variation entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Variations
                .Update(entity);
        }
    }
}
