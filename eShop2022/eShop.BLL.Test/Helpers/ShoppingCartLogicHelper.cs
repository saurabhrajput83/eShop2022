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
    public class ShoppingCartLogicHelper : BaseHelper<ShoppingCartView>
    {
        private readonly ILogicHelper _logicHelper;

        public ShoppingCartLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
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
            return _logicHelper.ShoppingCartLogic.Insert(shoppingCartView);
        }

        public override void Delete(Guid shoppingCartGuid)
        {
            _logicHelper.ShoppingCartLogic.Delete(shoppingCartGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
