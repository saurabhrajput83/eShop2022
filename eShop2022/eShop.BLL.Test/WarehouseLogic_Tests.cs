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
    public class WarehouseLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly WarehouseLogicHelper _WarehouseLogicHelper;
        
        public WarehouseLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _WarehouseLogicHelper = new WarehouseLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            warehouseView = _WarehouseLogicHelper.Insert(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<WarehouseMinimalView> warehouses;

            // Act
            warehouses = _appServices.WarehouseLogic.GetAll();

            // Assert
            Assert.IsTrue(warehouses.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            warehouseView = _appServices.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newWarehouseName = "Test New Warehouse Name";
            WarehouseFullView warehouseView;


            // Act
            warehouseView = _appServices.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            warehouseView.Name = newWarehouseName;
            _appServices.WarehouseLogic.Update(warehouseView);

            warehouseView = _appServices.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView) && warehouseView.Name == newWarehouseName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            _WarehouseLogicHelper.Delete(Constants.WarehouseGuid);
            _WarehouseLogicHelper.CleanUp();

            warehouseView = _appServices.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(warehouseView.IsNull());
        }
    }
}