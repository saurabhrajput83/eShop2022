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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
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


        public void Insert(Department entity)
        {
            CommandHelper.AddEntity(entity);

            _dbContext.Departments
                 .Add(entity);
        }

        public void Delete(Department entity)
        {
            _dbContext.Departments
                .Remove(entity);
        }

        public void Update(Department entity)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Departments
                .Update(entity);
        }

    }
}