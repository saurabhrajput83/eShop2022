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

        public async Task<DepartmentFullView> GetTestChildDepartment(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            DepartmentFullView parentDepartment = await _appServices.DepartmentLogic.GetByGuidAsync(parentDepartmentGuid);

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

        public override async Task<DepartmentFullView> InsertAsync(Guid departmentGuid)
        {
            DepartmentFullView department = GetTestDepartmentView(departmentGuid);
            return await _appServices.DepartmentLogic.InsertAsync(department);
        }

        public async Task<DepartmentFullView> InsertChild(Guid parentDepartmentGuid, Guid childDepartmentGuid)
        {
            DepartmentFullView childDepartment = await GetTestChildDepartment(parentDepartmentGuid, childDepartmentGuid);

            return await _appServices.DepartmentLogic.InsertAsync(childDepartment);
        }


        public override async Task DeleteAsync(Guid departmentGuid)
        {
            await _appServices.DepartmentLogic.DeleteAsync(departmentGuid);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
