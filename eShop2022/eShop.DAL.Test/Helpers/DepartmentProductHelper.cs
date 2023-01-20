using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class DepartmentProductHelper : BaseHelper<DepartmentProduct>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DepartmentHelper _departmentHelper;
        private readonly ProductHelper _productHelper;

        public DepartmentProductHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _departmentHelper = new DepartmentHelper(unitOfWork);
            _productHelper = new ProductHelper(unitOfWork);
        }

        public DepartmentProduct GetTestDepartmentProduct(Guid departmentProductGuid)
        {
            Department parentDepartment = _departmentHelper.Insert(Constants.DepartmentGuid);
            Department childDepartment = _departmentHelper.InsertChild(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);
            Product product = _productHelper.Insert(Constants.ProductGuid);

            DepartmentProduct departmentProduct = new DepartmentProduct()
            {
                DepartmentId = childDepartment.Id,
                ProductId = product.Id,
                Guid = departmentProductGuid
            };

            UpdateEntity(departmentProduct);

            return departmentProduct;

        }

        public override DepartmentProduct Insert(Guid departmentProductGuid)
        {
            DepartmentProduct departmentProduct = GetTestDepartmentProduct(departmentProductGuid);

            _unitOfWork.DepartmentProductRepository.Insert(departmentProduct);
            _unitOfWork.SaveChanges();

            return departmentProduct;
        }

        public override void Delete(Guid departmentProductGuid)
        {
            DepartmentProduct departmentProduct = _unitOfWork.DepartmentProductRepository.GetByGuid(departmentProductGuid);

            _unitOfWork.DepartmentProductRepository.Delete(departmentProduct);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _departmentHelper.Delete(Constants.ChildDepartmentGuid);
            _departmentHelper.Delete(Constants.DepartmentGuid);
            _departmentHelper.CleanUp();
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();
        }

    }
}
