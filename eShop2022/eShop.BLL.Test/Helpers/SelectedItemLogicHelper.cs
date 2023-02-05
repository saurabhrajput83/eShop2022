using AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logics;
using eShop.DAL.Entities;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class SelectedItemLogicHelper : BaseHelper<SelectedItemFullView>
    {
        private readonly IAppServices _appServices;
        private readonly ProductLogicHelper _ProductLogicHelper;
        private readonly ShoppingCartLogicHelper _ShoppingCartLogicHelper;

        public SelectedItemLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _ProductLogicHelper= new ProductLogicHelper(_appServices);
            _ShoppingCartLogicHelper = new ShoppingCartLogicHelper(_appServices);
        }

        public SelectedItemFullView GetTestSelectedItemView(Guid selectedItemGuid)
        {
            ProductFullView product = _ProductLogicHelper.Insert(Constants.ProductGuid);
            ShoppingCartView shoppingCart = _ShoppingCartLogicHelper.Insert(Constants.ShoppingCartGuid);

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
            return _appServices.SelectedItemLogic.Insert(selectedItemView);
        }

        public override void Delete(Guid selectedItemGuid)
        {
            _appServices.SelectedItemLogic.Delete(selectedItemGuid);
        }

        public override void CleanUp()
        {
            _ShoppingCartLogicHelper.Delete(Constants.ShoppingCartGuid);
            _ShoppingCartLogicHelper.CleanUp();
            _ProductLogicHelper.Delete(Constants.ProductGuid);
            _ProductLogicHelper.CleanUp();
        }

    }
}
