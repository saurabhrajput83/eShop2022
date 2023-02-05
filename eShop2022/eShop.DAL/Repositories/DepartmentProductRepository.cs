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
        private readonly eShopDbContext _dbContext;

        public DepartmentProductRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DepartmentProduct> GetAll()
        {
            return _dbContext.DepartmentProducts
                .Include(x => x.Department)
                .Include(x => x.Product)
                .AsEnumerable();
        }

        public DepartmentProduct GetByGuid(Guid guid)
        {
            return _dbContext.DepartmentProducts
                 .Include(x => x.Department).ThenInclude(x => x.Parent)
                 .Include(x => x.Product)
                 .FirstOrDefault(p => p.Guid == guid);
        }

        public void Insert(DepartmentProduct entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.DepartmentProducts
                  .Add(entity);
        }

        public void Delete(DepartmentProduct entity)
        {
            _dbContext.DepartmentProducts
                  .Remove(entity);
        }

        public void Update(DepartmentProduct entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.DepartmentProducts
                .Update(entity);
        }
    }
}
