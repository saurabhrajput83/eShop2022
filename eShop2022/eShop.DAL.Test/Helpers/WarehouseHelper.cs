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
        private readonly IeShopUnitOfWork _unitOfWork;

        public WarehouseHelper(IeShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public override Warehouse Insert(Guid warehouseGuid)
        {
            Warehouse warehouse = GetTestWarehouse(warehouseGuid);

            _unitOfWork.WarehouseRepository.Insert(warehouse);
            _unitOfWork.SaveChanges();

            return warehouse;
        }

        public override void Delete(Guid warehouseGuid)
        {
            Warehouse warehouse = _unitOfWork.WarehouseRepository.GetByGuid(Constants.WarehouseGuid);

            _unitOfWork.WarehouseRepository.Delete(warehouse);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
        }

    }
}
