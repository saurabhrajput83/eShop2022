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
        private readonly ProductLogicHelper _productLogicHelper;
        private readonly ShoppingCartLogicHelper _shoppingCartLogicHelper;

        public SelectedItemLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _productLogicHelper = new ProductLogicHelper(_appServices);
            _shoppingCartLogicHelper = new ShoppingCartLogicHelper(_appServices);
        }

        public async Task<SelectedItemFullView> GetTestSelectedItemView(Guid selectedItemGuid)
        {
            ProductFullView product = await _productLogicHelper.InsertAsync(Constants.ProductGuid);
            ShoppingCartView shoppingCart = await _shoppingCartLogicHelper.InsertAsync(Constants.ShoppingCartGuid);

            SelectedItemFullView selectedItem = new SelectedItemFullView()
            {
                Guid = selectedItemGuid,
                ProductId = product.Id,
                Quantity = 1,
                ShoppingCartId = shoppingCart.Id,

            };

            UpdateView(selectedItem);

            return selectedItem;

        }

        public override async Task<SelectedItemFullView> InsertAsync(Guid selectedItemGuid)
        {
            SelectedItemFullView selectedItemView = await GetTestSelectedItemView(selectedItemGuid);
            return await _appServices.SelectedItemLogic.InsertAsync(selectedItemView);
        }

        public override async Task DeleteAsync(Guid selectedItemGuid)
        {
            await _appServices.SelectedItemLogic.DeleteAsync(selectedItemGuid);
        }

        public override async Task CleanUpAsync()
        {
            await _shoppingCartLogicHelper.DeleteAsync(Constants.ShoppingCartGuid);
            await _shoppingCartLogicHelper.CleanUpAsync();
            await _productLogicHelper.DeleteAsync(Constants.ProductGuid);
            await _productLogicHelper.CleanUpAsync();
        }

    }
}
