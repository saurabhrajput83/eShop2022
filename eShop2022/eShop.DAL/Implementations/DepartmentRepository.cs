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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly eShopDbContext _dbContext;

        public DepartmentRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments
                   .Include(x => x.Parent)
                   .AsEnumerable();
        }

        public IEnumerable<Department> GetAllActive()
        {
            return _dbContext.Departments
                   .Include(x => x.Parent)
                   .Where(x => x.IsHidden == false)
                   .AsEnumerable();
        }

        public IEnumerable<Department> GetAllTopLevelDepartments()
        {
            return _dbContext.Departments
                   //.Include(x => x.Parent)
                   .Where(x => x.ParentId == null)
                   .AsEnumerable();
        }

        public IEnumerable<Department> GetByParentId(int parentId)
        {
            return _dbContext.Departments
                .Include(x => x.Parent)
                .Where(x => x.ParentId == parentId)
                .AsEnumerable();
        }


        public Department GetByGuid(Guid guid)
        {
            return _dbContext.Departments
                   .Include(x => x.Parent)
                   .FirstOrDefault(p => p.Guid == guid);
        }


        public Department Insert(Department entity)
        {
            return _dbContext.Departments
                  .Add(entity);
        }

        public Department Delete(Department entity)
        {
            return _dbContext.Departments
                 .Remove(entity);
        }

        public void Update(Department entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Set<Department>().AddOrUpdate(entity);
        }

    }
}