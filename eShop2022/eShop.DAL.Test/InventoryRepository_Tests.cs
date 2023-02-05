using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Test
{
    [TestClass]
    public class InventoryRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly InventoryHelper _inventoryHelper;

        public InventoryRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _token = new CancellationToken();
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _inventoryHelper = new InventoryHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Inventory inventory;

            // Act
            inventory = await _inventoryHelper.InsertAsync(Constants.InventoryGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Inventory> inventories;

            // Act
            inventories = await _unitOfWork.InventoryRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(inventories.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Inventory inventory;

            // Act
            inventory = await _unitOfWork.InventoryRepository.GetByGuidAsync(Constants.InventoryGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Inventory inventory;
            int newQuantity = 200;
            int newAlertQuantity = 20;

            // Act
            inventory = await _unitOfWork.InventoryRepository.GetByGuidAsync(Constants.InventoryGuid, _token);
            if (inventory != null)
            {
                inventory.Quantity = newQuantity;
                inventory.AlertQuantity = newAlertQuantity;
                _unitOfWork.InventoryRepository.Update(inventory, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory)
                && inventory.Quantity == newQuantity && inventory.AlertQuantity == newAlertQuantity);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Inventory inventory;

            // Act
            await _inventoryHelper.DeleteAsync(Constants.InventoryGuid);
            await _inventoryHelper.CleanUpAsync();

            inventory = await _unitOfWork.InventoryRepository.GetByGuidAsync(Constants.InventoryGuid, _token);

            //Assert
            Assert.IsTrue(inventory.IsNull());
        }


    }
}