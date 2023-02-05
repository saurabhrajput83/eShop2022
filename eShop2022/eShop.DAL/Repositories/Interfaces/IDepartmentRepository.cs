using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        IEnumerable<Department> GetAllTopLevelDepartments();

        IEnumerable<Department> GetByParentId(int parentId);
    }
}
