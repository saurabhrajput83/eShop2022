using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using eShop.BLL.Services;

namespace eShop.BLL.Test
{
    public class DepartmentProductLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly DepartmentProductLogicHelper _DepartmentProductLogicHelper;
        
        public DepartmentProductLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _DepartmentProductLogicHelper = new DepartmentProductLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            departmentProductView = _DepartmentProductLogicHelper.Insert(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<DepartmentProductMinimalView> departmentProducts;

            // Act
            departmentProducts = _appServices.DepartmentProductLogic.GetAll();

            // Assert
            Assert.IsTrue(departmentProducts.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            departmentProductView = _appServices.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView));
        }

        //[Test]
        //public void Test4_Update()
        //{
        //    // Arrange
        //    string newDepartmentProductName = "Test New DepartmentProduct Name";
        //    DepartmentProductFullView departmentProductView;


        //    // Act
        //    departmentProductView = _appServices.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

        //    departmentProductView.Name = newDepartmentProductName;
        //    _appServices.DepartmentProductLogic.Update(departmentProductView);

        //    departmentProductView = _appServices.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView) && departmentProductView.Name == newDepartmentProductName);
        //}

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            _DepartmentProductLogicHelper.Delete(Constants.DepartmentProductGuid);
            _DepartmentProductLogicHelper.CleanUp();

            departmentProductView = _appServices.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(departmentProductView.IsNull());
        }
    }
}