using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class DepartmentProductRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DepartmentHelper _departmentHelper;
        private readonly ProductHelper _productHelper;
        private readonly BrandHelper _brandHelper;
        private readonly DepartmentProductHelper _departmentProductHelper;

        public DepartmentProductRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _departmentHelper = new DepartmentHelper(_unitOfWork);
            _productHelper = new ProductHelper(_unitOfWork);
            _brandHelper = new BrandHelper(_unitOfWork);
            _departmentProductHelper = new DepartmentProductHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            departmentProduct = _departmentProductHelper.Insert(Constants.DepartmentProductGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProduct));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<DepartmentProduct> departmentProducts;

            // Act
            departmentProducts = _unitOfWork.DepartmentProductRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(departmentProducts.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            departmentProduct = _unitOfWork.DepartmentProductRepository.GetByGuid(Constants.DepartmentProductGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProduct));
            Assert.IsTrue(ValidationHelper.ValidateChildDepartment(departmentProduct.Department));
            Assert.IsTrue(ValidationHelper.ValidateProduct(departmentProduct.Product));
        }

        [TestMethod]
        public void Test4_Delete()
        {
            //Arrange
            DepartmentProduct departmentProduct;

            // Act
            _departmentProductHelper.Delete(Constants.DepartmentProductGuid);
            _departmentProductHelper.CleanUp();

            departmentProduct = _unitOfWork.DepartmentProductRepository.GetByGuid(Constants.DepartmentProductGuid);


            //Assert
            Assert.IsTrue(departmentProduct.IsNull());

        }


    }
}