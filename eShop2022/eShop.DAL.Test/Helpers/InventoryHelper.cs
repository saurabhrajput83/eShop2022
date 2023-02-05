using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class InventoryHelper : BaseHelper<Inventory>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly ProductHelper _productHelper;
        private readonly WarehouseHelper _warehouseHelper;

        public InventoryHelper(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productHelper = new ProductHelper(_unitOfWork);
            _warehouseHelper = new WarehouseHelper(_unitOfWork);
        }

        public Inventory GetTestInventory(Guid inventoryGuid)
        {
            Product product = _productHelper.Insert(Constants.ProductGuid);
            Warehouse warehouse = _warehouseHelper.Insert(Constants.WarehouseGuid);

            Inventory inventory = new Inventory()
            {
                Guid = inventoryGuid,
                AlertQuantity = 10,
                ProductId = product.Id,
                Quantity = 100,
                WarehouseId = warehouse.Id
            };

            UpdateEntity(inventory);

            return inventory;

        }

        public override Inventory Insert(Guid inventoryGuid)
        {
            Inventory inventory = GetTestInventory(inventoryGuid);

            _unitOfWork.InventoryRepository.Insert(inventory);
            _unitOfWork.SaveChanges();

            return inventory;
        }

        public override void Delete(Guid inventoryGuid)
        {
            Inventory inventory = _unitOfWork.InventoryRepository.GetByGuid(Constants.InventoryGuid);

            _unitOfWork.InventoryRepository.Delete(inventory);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();
            _warehouseHelper.Delete(Constants.WarehouseGuid);
            _warehouseHelper.CleanUp();
        }

    }
}
