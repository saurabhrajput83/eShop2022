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
    public class ShoppingCartLogicHelper : BaseHelper<ShoppingCartView>
    {
        private readonly IAppServices _appServices;

        public ShoppingCartLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
        }

        public ShoppingCartView GetTestShoppingCartView(Guid shoppingCartGuid)
        {
            ShoppingCartView shoppingCartView = new ShoppingCartView()
            {
                Guid = shoppingCartGuid
            };

            UpdateView(shoppingCartView);

            return shoppingCartView;

        }

        public override async Task<ShoppingCartView> InsertAsync(Guid shoppingCartGuid)
        {
            ShoppingCartView shoppingCartView = GetTestShoppingCartView(shoppingCartGuid);
            return await _appServices.ShoppingCartLogic.InsertAsync(shoppingCartView);
        }

        public override async Task DeleteAsync(Guid shoppingCartGuid)
        {
            await _appServices.ShoppingCartLogic.DeleteAsync(shoppingCartGuid);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
