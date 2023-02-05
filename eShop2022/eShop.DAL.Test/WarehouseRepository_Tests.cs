using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class WarehouseRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly WarehouseHelper _warehouseHelper;

        public WarehouseRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new eShopUnitOfWork(_eShopDbContext);
            _warehouseHelper = new WarehouseHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            warehouse = _warehouseHelper.Insert(Constants.WarehouseGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Warehouse> warehouses;

            // Act
            warehouses = _unitOfWork.WarehouseRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(warehouses.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            warehouse = _unitOfWork.WarehouseRepository.GetByGuid(Constants.WarehouseGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Warehouse warehouse;
            string newName = "Test New Warehouse";

            // Act
            warehouse = _unitOfWork.WarehouseRepository.GetByGuid(Constants.WarehouseGuid);
            if (warehouse != null)
            {
                warehouse.Name = newName;
                _unitOfWork.WarehouseRepository.Update(warehouse);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse) && warehouse?.Name == newName);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            _warehouseHelper.Delete(Constants.WarehouseGuid);
            _warehouseHelper.CleanUp();

            warehouse = _unitOfWork.WarehouseRepository.GetByGuid(Constants.WarehouseGuid);

            //Assert
            Assert.IsTrue(warehouse.IsNull());
        }


    }
}