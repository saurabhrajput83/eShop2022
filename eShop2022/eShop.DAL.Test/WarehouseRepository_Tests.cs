using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace eShop.DAL.Test
{
    [TestClass]
    public class WarehouseRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly WarehouseHelper _warehouseHelper;

        public WarehouseRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _warehouseHelper = new WarehouseHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            warehouse = await _warehouseHelper.InsertAsync(Constants.WarehouseGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Warehouse> warehouses;

            // Act
            warehouses = await _unitOfWork.WarehouseRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(warehouses.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            warehouse = await _unitOfWork.WarehouseRepository.GetByGuidAsync(Constants.WarehouseGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Warehouse warehouse;
            string newName = "Test New Warehouse";

            // Act
            warehouse = await _unitOfWork.WarehouseRepository.GetByGuidAsync(Constants.WarehouseGuid, _token);
            if (warehouse != null)
            {
                warehouse.Name = newName;
                _unitOfWork.WarehouseRepository.Update(warehouse, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateWarehouse(warehouse) && warehouse?.Name == newName);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Warehouse warehouse;

            // Act
            await _warehouseHelper.DeleteAsync(Constants.WarehouseGuid);
            await _warehouseHelper.CleanUpAsync();

            warehouse = await _unitOfWork.WarehouseRepository.GetByGuidAsync(Constants.WarehouseGuid, _token);

            //Assert
            Assert.IsTrue(warehouse.IsNull());
        }


    }
}