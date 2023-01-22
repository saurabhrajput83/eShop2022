using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace eShop.BLL.Test
{
    public class DepartmentProductLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly DepartmentProductLogicHelper _departmentProductLogicHelper;
        
        public DepartmentProductLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _departmentProductLogicHelper = new DepartmentProductLogicHelper(_logicHelper);
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
            departmentProductView = _departmentProductLogicHelper.Insert(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<DepartmentProductMinimalView> departmentProducts;

            // Act
            departmentProducts = _logicHelper.DepartmentProductLogic.GetAll();

            // Assert
            Assert.IsTrue(departmentProducts.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            departmentProductView = _logicHelper.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

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
        //    departmentProductView = _logicHelper.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

        //    departmentProductView.Name = newDepartmentProductName;
        //    _logicHelper.DepartmentProductLogic.Update(departmentProductView);

        //    departmentProductView = _logicHelper.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateDepartmentProduct(departmentProductView) && departmentProductView.Name == newDepartmentProductName);
        //}

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            DepartmentProductFullView departmentProductView;

            // Act
            _departmentProductLogicHelper.Delete(Constants.DepartmentProductGuid);
            _departmentProductLogicHelper.CleanUp();

            departmentProductView = _logicHelper.DepartmentProductLogic.GetByGuid(Constants.DepartmentProductGuid);

            // Assert
            Assert.IsTrue(departmentProductView.IsNull());
        }
    }
}