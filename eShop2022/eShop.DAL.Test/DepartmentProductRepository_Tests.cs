using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace eShop.DAL.Test
{
    [TestClass]
    public class DepartmentProductRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly DepartmentHelper _departmentHelper;
        private readonly ProductHelper _productHelper;
        private readonly BrandHelper _brandHelper;
        private readonly DepartmentProductHelper _departmentProductHelper;

        public DepartmentProductRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _departmentHelper = new DepartmentHelper(_unitOfWork, _token);
            _productHelper = new ProductHelper(_unitOfWork, _token);
            _brandHelper = new BrandHelper(_unitOfWork, _token);
            _departmentProductHelper = new DepartmentProductHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            departmentProduct = await _departmentProductHelper.InsertAsync(Constants.DepartmentProductGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProduct));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<DepartmentProduct> departmentProducts;

            // Act
            departmentProducts = await _unitOfWork.DepartmentProductRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(departmentProducts.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            departmentProduct = await _unitOfWork.DepartmentProductRepository.GetByGuidAsync(Constants.DepartmentProductGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProduct));
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(departmentProduct.Department));
            Assert.IsTrue(ValidationHelper.ValidateProduct(departmentProduct.Product));
        }

        [TestMethod]
        public async Task Test4_Delete()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            await _departmentProductHelper.DeleteAsync(Constants.DepartmentProductGuid);
            await _departmentProductHelper.CleanUpAsync();

            departmentProduct = await _unitOfWork.DepartmentProductRepository.GetByGuidAsync(Constants.DepartmentProductGuid, _token);


            //Assert
            Assert.IsTrue(departmentProduct.IsNull());

        }


    }
}