using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class DepartmentHelper : BaseHelper<Department>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;


        public DepartmentHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public Department GetTestDepartment(Guid departmentGuid)
        {
            Department parentDepartment = new Department()
            {
                Guid = departmentGuid,
                Name = "Test Department Name",
                Description = "Test Department Description",
                IsHidden = false,
                ParentId = null
            };

            UpdateEntity(parentDepartment);

            return parentDepartment;

        }

        public async Task<Department> GetTestChildDepartment(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            Department parentDepartment = await _unitOfWork.DepartmentRepository.GetByGuidAsync(parentDepartmentGuid, _token);

            Department childDepartment = new Department()
            {
                Guid = childDepartmentGuid,
                Name = "Test Child Department Name",
                Description = "Test Child Department Description",
                IsHidden = false,
                ParentId = parentDepartment.Id
            };

            UpdateEntity(childDepartment);

            return childDepartment;

        }

        public override async Task<Department> InsertAsync(Guid departmentGuid)
        {
            Department department = GetTestDepartment(departmentGuid);

            await _unitOfWork.DepartmentRepository.InsertAsync(department, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return department;
        }

        public async Task<Department> InsertChildAsync(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            Department childDepartment = await GetTestChildDepartment(parentDepartmentGuid, childDepartmentGuid);

            await _unitOfWork.DepartmentRepository.InsertAsync(childDepartment, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return childDepartment;
        }

        public override async Task DeleteAsync(Guid departmentGuid)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetByGuidAsync(departmentGuid, _token);

            _unitOfWork.DepartmentRepository.Delete(department, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {

        }

    }
}
