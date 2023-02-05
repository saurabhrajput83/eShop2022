using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class DepartmentProductLogicHelper : BaseHelper<DepartmentProductFullView>
    {
        private readonly IAppServices _appServices;
        private readonly DepartmentLogicHelper _departmentLogicHelper;
        private readonly ProductLogicHelper _productLogicHelper;

        public DepartmentProductLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _departmentLogicHelper = new DepartmentLogicHelper(_appServices);
            _productLogicHelper = new ProductLogicHelper(_appServices);
        }

        public async Task<DepartmentProductFullView> GetTestDepartmentProductView(Guid departmentProductGuid)
        {
            DepartmentFullView parentDepartment = await _departmentLogicHelper.InsertAsync(Constants.DepartmentGuid);
            DepartmentFullView childDepartment = await _departmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);
            ProductFullView product = await _productLogicHelper.InsertAsync(Constants.ProductGuid);

            DepartmentProductFullView departmentProduct = new DepartmentProductFullView()
            {
                DepartmentId = childDepartment.Id,
                ProductId = product.Id,
                Guid = departmentProductGuid
            };

            UpdateView(departmentProduct);

            return departmentProduct;

        }

        public override async Task<DepartmentProductFullView> InsertAsync(Guid departmentProductGuid)
        {
            DepartmentProductFullView departmentProductView = await GetTestDepartmentProductView(departmentProductGuid);
            return await _appServices.DepartmentProductLogic.InsertAsync(departmentProductView);
        }

        public override async Task DeleteAsync(Guid departmentProductGuid)
        {
            await _appServices.DepartmentProductLogic.DeleteAsync(departmentProductGuid);
        }

        public override async Task CleanUpAsync()
        {
            await _departmentLogicHelper.DeleteAsync(Constants.ChildDepartmentGuid);
            await _departmentLogicHelper.DeleteAsync(Constants.DepartmentGuid);
            await _departmentLogicHelper.CleanUpAsync();

            await _productLogicHelper.DeleteAsync(Constants.ProductGuid);
            await _productLogicHelper.CleanUpAsync();
        }

    }
}
