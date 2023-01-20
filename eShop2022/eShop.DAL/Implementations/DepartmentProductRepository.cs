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
                //.Include(x => x.Department)
                //.Include(x => x.Product)
                .AsEnumerable();
        }

        public DepartmentProduct GetByGuid(Guid guid)
        {
            return _dbContext.DepartmentProducts
                 .Include(x => x.Department)
                 .Include(x => x.Product)
                 .FirstOrDefault(p => p.Guid == guid);
        }

        public DepartmentProduct Insert(DepartmentProduct entity)
        {
            CommandHelper.AddEntity(entity);

            return _dbContext.DepartmentProducts
                   .Add(entity);
        }

        public DepartmentProduct Delete(DepartmentProduct entity)
        {
            return _dbContext.DepartmentProducts
                   .Remove(entity);
        }

        public void Update(DepartmentProduct entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<DepartmentProduct>().AddOrUpdate(entity);
        }
    }
}
