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
    public class WarehouseLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly WarehouseLogicHelper _warehouseLogicHelper;
        
        public WarehouseLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _warehouseLogicHelper = new WarehouseLogicHelper(_logicHelper);
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
            warehouseView = _warehouseLogicHelper.Insert(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<WarehouseMinimalView> warehouses;

            // Act
            warehouses = _logicHelper.WarehouseLogic.GetAll();

            // Assert
            Assert.IsTrue(warehouses.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            warehouseView = _logicHelper.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

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
            warehouseView = _logicHelper.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            warehouseView.Name = newWarehouseName;
            _logicHelper.WarehouseLogic.Update(warehouseView);

            warehouseView = _logicHelper.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouseView) && warehouseView.Name == newWarehouseName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            WarehouseFullView warehouseView;

            // Act
            _warehouseLogicHelper.Delete(Constants.WarehouseGuid);
            _warehouseLogicHelper.CleanUp();

            warehouseView = _logicHelper.WarehouseLogic.GetByGuid(Constants.WarehouseGuid);

            // Assert
            Assert.IsTrue(warehouseView.IsNull());
        }
    }
}