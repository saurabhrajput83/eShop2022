using AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Services;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class DepartmentLogicHelper : BaseHelper<DepartmentFullView>
    {
        private readonly IAppServices _appServices;

        public DepartmentLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
        }


        public DepartmentFullView GetTestDepartmentView(Guid departmentGuid)
        {
            DepartmentFullView parentDepartment = new DepartmentFullView()
            {
                Guid = departmentGuid,
                Name = "Test Department Name",
                Description = "Test Department Description",
                IsHidden = false,
                ParentId = null
            };

            UpdateView(parentDepartment);

            return parentDepartment;

        }

        public DepartmentFullView GetTestChildDepartment(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            DepartmentFullView parentDepartment = _appServices.DepartmentLogic.GetByGuid(parentDepartmentGuid);

            DepartmentFullView childDepartment = new DepartmentFullView()
            {
                Guid = childDepartmentGuid,
                Name = "Test Child Department Name",
                Description = "Test Child Department Description",
                IsHidden = false,
                ParentId = parentDepartment.Id
            };

            UpdateView(childDepartment);

            return childDepartment;

        }

        public override DepartmentFullView Insert(Guid departmentGuid)
        {
            DepartmentFullView department = GetTestDepartmentView(departmentGuid);
            return _appServices.DepartmentLogic.Insert(department);
        }

        public DepartmentFullView InsertChild(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            DepartmentFullView childDepartment = GetTestChildDepartment(parentDepartmentGuid, childDepartmentGuid);

            return _appServices.DepartmentLogic.Insert(childDepartment);
        }


        public override void Delete(Guid departmentGuid)
        {
            _appServices.DepartmentLogic.Delete(departmentGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
