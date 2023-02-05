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
        public async Task Test1_Insert()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            warehouseView = await _WarehouseLogicHelper.InsertAsync(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<WarehouseMinimalView> warehouses;

            // Act
            warehouses = await _appServices.WarehouseLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(warehouses.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            warehouseView = await _appServices.WarehouseLogic.GetByGuidAsync(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newWarehouseName = "Test New Warehouse Name";
            WarehouseFullView warehouseView;


            // Act
            warehouseView = await _appServices.WarehouseLogic.GetByGuidAsync(Constants.WarehouseGuid);

            warehouseView.Name = newWarehouseName;
            await _appServices.WarehouseLogic.UpdateAsync(warehouseView);

            warehouseView = await _appServices.WarehouseLogic.GetByGuidAsync(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView) && warehouseView.Name == newWarehouseName);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            await _WarehouseLogicHelper.DeleteAsync(Constants.WarehouseGuid);
            await _WarehouseLogicHelper.CleanUpAsync();

            warehouseView = await _appServices.WarehouseLogic.GetByGuidAsync(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(warehouseView.IsNull());
        }
    }
}