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
        private readonly DepartmentProductLogicHelper _departmentProductLogicHelper;

        public DepartmentProductLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _departmentProductLogicHelper = new DepartmentProductLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            departmentProductView = await _departmentProductLogicHelper.InsertAsync(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<DepartmentProductMinimalView> departmentProducts;

            // Act
            departmentProducts = await _appServices.DepartmentProductLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(departmentProducts.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            departmentProductView = await _appServices.DepartmentProductLogic.GetByGuidAsync(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView));
        }

        //[Test]
        //public async Task Test4_Update()
        //{
        //    // Arrange
        //    string newDepartmentProductName = "Test New DepartmentProduct Name";
        //    DepartmentProductFullView departmentProductView;


        //    // Act
        //    departmentProductView = _appServices.DepartmentProductLogic.GetByGuidAsync(Constants.DepartmentProductGuid);

        //    departmentProductView.Name = newDepartmentProductName;
        //    _appServices.DepartmentProductLogic.Update(departmentProductView);

        //    departmentProductView = _appServices.DepartmentProductLogic.GetByGuidAsync(Constants.DepartmentProductGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView) && departmentProductView.Name == newDepartmentProductName);
        //}

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            await _departmentProductLogicHelper.DeleteAsync(Constants.DepartmentProductGuid);
            await _departmentProductLogicHelper.CleanUpAsync();

            departmentProductView = await _appServices.DepartmentProductLogic.GetByGuidAsync(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(departmentProductView.IsNull());
        }
    }
}