using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class DepartmentProductLogicHelper : BaseHelper<DepartmentProductFullView>
    {
        private readonly ILogicHelper _logicHelper;
        private readonly DepartmentLogicHelper _departmentLogicHelper;
        private readonly ProductLogicHelper _productLogicHelper;

        public DepartmentProductLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
            _departmentLogicHelper= new DepartmentLogicHelper(_logicHelper);
            _productLogicHelper = new ProductLogicHelper(_logicHelper); 
        }

        public DepartmentProductFullView GetTestDepartmentProductView(Guid departmentProductGuid)
        {
            DepartmentFullView parentDepartment = _departmentLogicHelper.Insert(Constants.DepartmentGuid);
            DepartmentFullView childDepartment = _departmentLogicHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);
            ProductFullView product = _productLogicHelper.Insert(Constants.ProductGuid);

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
            return _logicHelper.DepartmentProductLogic.Insert(departmentProductView);
        }

        public override void Delete(Guid departmentProductGuid)
        {
            _logicHelper.DepartmentProductLogic.Delete(departmentProductGuid);
        }

        public override void CleanUp()
        {
            _departmentLogicHelper.Delete(Constants.ChildDepartmentGuid);
            _departmentLogicHelper.Delete(Constants.DepartmentGuid);
            _departmentLogicHelper.CleanUp();

            _productLogicHelper.Delete(Constants.ProductGuid);
            _productLogicHelper.CleanUp();
        }

    }
}
