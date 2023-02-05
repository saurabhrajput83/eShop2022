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
        private readonly DepartmentLogicHelper _DepartmentLogicHelper;
        private readonly ProductLogicHelper _ProductLogicHelper;

        public DepartmentProductLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _DepartmentLogicHelper= new DepartmentLogicHelper(_appServices);
            _ProductLogicHelper = new ProductLogicHelper(_appServices); 
        }

        public DepartmentProductFullView GetTestDepartmentProductView(Guid departmentProductGuid)
        {
            DepartmentFullView parentDepartment = _DepartmentLogicHelper.Insert(Constants.DepartmentGuid);
            DepartmentFullView childDepartment = _DepartmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);
            ProductFullView product = _ProductLogicHelper.Insert(Constants.ProductGuid);

            DepartmentProductFullView departmentProduct = new DepartmentProductFullView()
            {
                DepartmentId = childDepartment.Id,
                ProductId = product.Id,
                Guid = departmentProductGuid
            };

            UpdateView(departmentProduct);

            return departmentProduct;

        }

        public override DepartmentProductFullView Insert(Guid departmentProductGuid)
        {
            DepartmentProductFullView departmentProductView = GetTestDepartmentProductView(departmentProductGuid);
            return _appServices.DepartmentProductLogic.Insert(departmentProductView);
        }

        public override void Delete(Guid departmentProductGuid)
        {
            _appServices.DepartmentProductLogic.Delete(departmentProductGuid);
        }

        public override void CleanUp()
        {
            _DepartmentLogicHelper.Delete(Constants.ChildDepartmentGuid);
            _DepartmentLogicHelper.Delete(Constants.DepartmentGuid);
            _DepartmentLogicHelper.CleanUp();

            _ProductLogicHelper.Delete(Constants.ProductGuid);
            _ProductLogicHelper.CleanUp();
        }

    }
}
