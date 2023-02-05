using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using Newtonsoft.Json.Linq;
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
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly DepartmentHelper _departmentHelper;
        private readonly ProductHelper _productHelper;

        public DepartmentProductHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _departmentHelper = new DepartmentHelper(unitOfWork, _token);
            _productHelper = new ProductHelper(unitOfWork, _token);
        }

        public async Task<DepartmentProduct> GetTestDepartmentProduct(Guid departmentProductGuid)
        {
            Department parentDepartment = await _departmentHelper.InsertAsync(Constants.DepartmentGuid);
            Department childDepartment = await _departmentHelper.InsertChildAsync(Constants.DepartmentGuid, Constants.ChildDepartmentGuid);
            Product product = await _productHelper.InsertAsync(Constants.ProductGuid);

            DepartmentProduct departmentProduct = new DepartmentProduct()
            {
                DepartmentId = childDepartment.Id,
                ProductId = product.Id,
                Guid = departmentProductGuid
            };

            UpdateEntity(departmentProduct);

            return departmentProduct;

        }

        public override async Task<DepartmentProduct> InsertAsync(Guid departmentProductGuid)
        {
            DepartmentProduct departmentProduct = await GetTestDepartmentProduct(departmentProductGuid);

            await _unitOfWork.DepartmentProductRepository.InsertAsync(departmentProduct, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return departmentProduct;
        }

        public override async Task DeleteAsync(Guid departmentProductGuid)
        {
            DepartmentProduct departmentProduct = await _unitOfWork.DepartmentProductRepository.GetByGuidAsync(departmentProductGuid, _token);

            _unitOfWork.DepartmentProductRepository.Delete(departmentProduct, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _departmentHelper.DeleteAsync(Constants.ChildDepartmentGuid);
            await _departmentHelper.DeleteAsync(Constants.DepartmentGuid);
            await _departmentHelper.CleanUpAsync();
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();
        }

    }
}
