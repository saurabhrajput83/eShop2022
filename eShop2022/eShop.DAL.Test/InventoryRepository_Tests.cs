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
        private readonly eShopDbContext _eShopDbContext;
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly InventoryHelper _inventoryHelper;

        public InventoryRepository_Tests()
        {
            DbContextOptions<eShopDbContext> dbContextOptions =
            new DbContextOptionsBuilder<eShopDbContext>()
            .UseInMemoryDatabase(databaseName: "eShopDb")
            .Options;

            _eShopDbContext = new eShopDbContext(dbContextOptions);
            _unitOfWork = new eShopUnitOfWork(_eShopDbContext);
            _inventoryHelper = new InventoryHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Inventory inventory;

            // Act
            inventory = _inventoryHelper.Insert(Constants.InventoryGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Inventory> inventories;

            // Act
            inventories = _unitOfWork.InventoryRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(inventories.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Inventory inventory;

            // Act
            inventory = _unitOfWork.InventoryRepository.GetByGuid(Constants.InventoryGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Inventory inventory;
            int newQuantity = 200;
            int newAlertQuantity = 20;

            // Act
            inventory = _unitOfWork.InventoryRepository.GetByGuid(Constants.InventoryGuid);
            if (inventory != null)
            {
                inventory.Quantity = newQuantity;
                inventory.AlertQuantity = newAlertQuantity;
                _unitOfWork.InventoryRepository.Update(inventory);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateInventory(inventory)
                && inventory.Quantity == newQuantity && inventory.AlertQuantity == newAlertQuantity);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Inventory inventory;

            // Act
            _inventoryHelper.Delete(Constants.InventoryGuid);
            _inventoryHelper.CleanUp();

            inventory = _unitOfWork.InventoryRepository.GetByGuid(Constants.InventoryGuid);

            //Assert
            Assert.IsTrue(inventory.IsNull());
        }


    }
}