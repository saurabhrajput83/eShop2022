using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class WarehouseLogicHelper : BaseHelper<WarehouseFullView>
    {
        private readonly ILogicHelper _logicHelper;

        public WarehouseLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
        }

        public WarehouseFullView GetTestWarehouseView(Guid warehouseGuid)
        {
            WarehouseFullView warehouseView = new WarehouseFullView()
            {
                Guid = warehouseGuid,
                Name = "Test Warehouse Name",
                Description = "Test Warehouse Description",
                IsHidden = false,
                Url = "",
            };

            UpdateView(warehouseView);

            return warehouseView;

        }

        public override WarehouseFullView Insert(Guid warehouseGuid)
        {
            WarehouseFullView warehouseView = GetTestWarehouseView(warehouseGuid);
            return _logicHelper.WarehouseLogic.Insert(warehouseView);
        }

        public override void Delete(Guid warehouseGuid)
        {
            _logicHelper.WarehouseLogic.Delete(warehouseGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
