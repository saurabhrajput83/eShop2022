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
        private readonly CancellationToken _token;
        private readonly ProductHelper _productHelper;
        private readonly WarehouseHelper _warehouseHelper;

        public InventoryHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _productHelper = new ProductHelper(_unitOfWork, _token);
            _warehouseHelper = new WarehouseHelper(_unitOfWork, _token);

        }

        public async Task<Inventory> GetTestInventory(Guid inventoryGuid)
        {
            Product product = await _productHelper.InsertAsync(Constants.ProductGuid);
            Warehouse warehouse = await _warehouseHelper.InsertAsync(Constants.WarehouseGuid);

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

        public override async Task<Inventory> InsertAsync(Guid inventoryGuid)
        {
            Inventory inventory = await GetTestInventory(inventoryGuid);

            await _unitOfWork.InventoryRepository.InsertAsync(inventory, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return inventory;
        }

        public override async Task DeleteAsync(Guid inventoryGuid)
        {
            Inventory inventory = await _unitOfWork.InventoryRepository.GetByGuidAsync(Constants.InventoryGuid, _token);

            _unitOfWork.InventoryRepository.Delete(inventory, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();
            await _warehouseHelper.DeleteAsync(Constants.WarehouseGuid);
            await _warehouseHelper.CleanUpAsync();
        }

    }
}
