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

        public async Task<List<Department>> GetAllAsync(CancellationToken token)
        {
            IQueryable<Department> results = _dbContext.Departments
                   .Include(x => x.Parent);
            return await results.ToListAsync(token);
        }

        //public IEnumerable<Department> GetAllActive(CancellationToken token)
        //{
        //    return _dbContext.Departments
        //           .Include(x => x.Parent)
        //           .Where(x => x.IsHidden == false)
        //           .AsEnumerable();
        //}

        //public IEnumerable<Department> GetAllTopLevelDepartments()
        //{
        //    return _dbContext.Departments
        //           //.Include(x => x.Parent)
        //           .Where(x => x.ParentId == null)
        //           .AsEnumerable();
        //}

        //public IEnumerable<Department> GetByParentId(int parentId)
        //{
        //    return _dbContext.Departments
        //        .Include(x => x.Parent)
        //        .Where(x => x.ParentId == parentId)
        //        .AsEnumerable();
        //}


        public async Task<Department> GetByGuidAsync(Guid guid, CancellationToken token)
        {
            return await _dbContext.Departments
                   .Include(x => x.Parent)
                   .FirstOrDefaultAsync(p => p.Guid == guid, token);
        }


        public async Task InsertAsync(Department entity, CancellationToken token)
        {
            CommandHelper.AddEntity(entity);

            await _dbContext.Departments
                   .AddAsync(entity, token);
        }

        public void Delete(Department entity, CancellationToken token)
        {
            _dbContext.Departments
                .Remove(entity);
        }

        public void Update(Department entity, CancellationToken token)
        {
            CommandHelper.UpdateEntity(entity);

            _dbContext.Departments
                .Update(entity);
        }

    }
}