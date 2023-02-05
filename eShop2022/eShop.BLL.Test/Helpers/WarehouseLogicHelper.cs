using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class WarehouseLogicHelper : BaseHelper<WarehouseFullView>
    {
        private readonly IAppServices _appServices;

        public WarehouseLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
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
            return _appServices.WarehouseLogic.Insert(warehouseView);
        }

        public override void Delete(Guid warehouseGuid)
        {
            _appServices.WarehouseLogic.Delete(warehouseGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
