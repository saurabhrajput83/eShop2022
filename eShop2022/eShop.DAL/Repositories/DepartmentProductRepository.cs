using eShop.DAL.Entities;
using eShop.DAL.Helpers;
using eShop.DAL.Repositories.Interfaces;
using eShop.DAL.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Implementations.Repositories
{
    public class DepartmentProductRepository : IDepartmentProductRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DepartmentProduct>> GetAllAsync(CancellationToken token)
        {
            IQueryable<DepartmentProduct> results = _dbContext.DepartmentProducts
                .Include(x => x.Department)
                .Include(x => x.Product);
            return await results.ToListAsync(token);
        }

        public async Task<DepartmentProduct> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.DepartmentProducts
                 .Include(x => x.Department).ThenInclude(x => x.Parent)
                 .Include(x => x.Product)
                 .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }

        public async Task InsertAsync(DepartmentProduct entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.DepartmentProducts
                .AddAsync(entity, token);
        }

        public void Delete(DepartmentProduct entity, CancellationToken token)
        {
            _dbContext.DepartmentProducts
                  .Remove(entity);
        }

        public void Update(DepartmentProduct entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.DepartmentProducts
                .Update(entity);
        }
    }
}
