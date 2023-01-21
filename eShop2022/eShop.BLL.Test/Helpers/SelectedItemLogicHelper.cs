using AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logics;
using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class SelectedItemLogicHelper : BaseHelper<SelectedItemFullView>
    {
        private readonly ILogicHelper _logicHelper;
        private readonly ProductLogicHelper _productLogicHelper;
        private readonly ShoppingCartLogicHelper _shoppingCartLogicHelper;

        public SelectedItemLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
            _productLogicHelper= new ProductLogicHelper(_logicHelper);
            _shoppingCartLogicHelper = new ShoppingCartLogicHelper(_logicHelper);
        }

        public SelectedItemFullView GetTestSelectedItemView(Guid selectedItemGuid)
        {
            ProductFullView product = _productLogicHelper.Insert(Constants.ProductGuid);
            ShoppingCartView shoppingCart = _shoppingCartLogicHelper.Insert(Constants.ShoppingCartGuid);

            SelectedItemFullView  selectedItem = new SelectedItemFullView()
            {
                Guid = selectedItemGuid,
                ProductId = product.Id,
                Quantity = 1,
                ShoppingCartId = shoppingCart.Id,

            };

            UpdateView(selectedItem);

            return selectedItem;

        }

        public override SelectedItemFullView Insert(Guid selectedItemGuid)
        {
            SelectedItemFullView selectedItemView = GetTestSelectedItemView(selectedItemGuid);
            return _logicHelper.SelectedItemLogic.Insert(selectedItemView);
        }

        public override void Delete(Guid selectedItemGuid)
        {
            _logicHelper.SelectedItemLogic.Delete(selectedItemGuid);
        }

        public override void CleanUp()
        {
            _shoppingCartLogicHelper.Delete(Constants.ShoppingCartGuid);
            _shoppingCartLogicHelper.CleanUp();
            _productLogicHelper.Delete(Constants.ProductGuid);
            _productLogicHelper.CleanUp();
        }

    }
}
