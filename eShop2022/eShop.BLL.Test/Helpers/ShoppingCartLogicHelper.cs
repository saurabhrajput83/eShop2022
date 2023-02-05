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

        public override ShoppingCartView Insert(Guid shoppingCartGuid)
        {
            ShoppingCartView shoppingCartView = GetTestShoppingCartView(shoppingCartGuid);
            return _appServices.ShoppingCartLogic.Insert(shoppingCartView);
        }

        public override void Delete(Guid shoppingCartGuid)
        {
            _appServices.ShoppingCartLogic.Delete(shoppingCartGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
