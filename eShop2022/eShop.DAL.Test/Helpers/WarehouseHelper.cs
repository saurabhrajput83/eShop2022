using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class WarehouseHelper : BaseHelper<Warehouse>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;

        public WarehouseHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public Warehouse GetTestWarehouse(Guid warehouseGuid)
        {
            Warehouse warehouse = new Warehouse()
            {
                Guid = warehouseGuid,
                Name = "Test Warehouse Name",
                Description = "Test Warehouse Description",
                IsHidden = false,
                Url = "",
            };

            UpdateEntity(warehouse);

            return warehouse;

        }

        public override async Task<Warehouse> InsertAsync(Guid warehouseGuid)
        {
            Warehouse warehouse = GetTestWarehouse(warehouseGuid);

            await _unitOfWork.WarehouseRepository.InsertAsync(warehouse, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return warehouse;
        }

        public override async Task DeleteAsync(Guid warehouseGuid)
        {
            Warehouse warehouse = await _unitOfWork.WarehouseRepository.GetByGuidAsync(Constants.WarehouseGuid, _token);

            _unitOfWork.WarehouseRepository.Delete(warehouse, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
