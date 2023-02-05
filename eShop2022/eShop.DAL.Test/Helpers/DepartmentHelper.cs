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

        public DepartmentHelper(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public Department GetTestChildDepartment(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            Department parentDepartment = _unitOfWork.DepartmentRepository.GetByGuid(parentDepartmentGuid);

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

        public override Department Insert(Guid departmentGuid)
        {
            Department department = GetTestDepartment(departmentGuid);

            _unitOfWork.DepartmentRepository.Insert(department);
            _unitOfWork.SaveChanges();

            return department;
        }

        public Department InsertChild(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            Department childDepartment = GetTestChildDepartment(parentDepartmentGuid, childDepartmentGuid);

            _unitOfWork.DepartmentRepository.Insert(childDepartment);
            _unitOfWork.SaveChanges();

            return childDepartment;
        }

        public override void Delete(Guid departmentGuid)
        {
            Department department = _unitOfWork.DepartmentRepository.GetByGuid(departmentGuid);

            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {

        }

    }
}
