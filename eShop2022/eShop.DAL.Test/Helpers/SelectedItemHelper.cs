using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class SelectedItemHelper : BaseHelper<SelectedItem>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ProductHelper _productHelper;
        private readonly ShoppingCartHelper _shoppingCartHelper;

        public SelectedItemHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _productHelper = new ProductHelper(unitOfWork, _token);
            _shoppingCartHelper = new ShoppingCartHelper(unitOfWork, _token);

        }

        public async Task<SelectedItem> GetTestSelectedItem(Guid selectedItemGuid)
        {
            Product product = await _productHelper.InsertAsync(Constants.ProductGuid);
            ShoppingCart shoppingCart = await _shoppingCartHelper.InsertAsync(Constants.ShoppingCartGuid);

            SelectedItem selectedItem = new SelectedItem()
            {
                Guid = selectedItemGuid,
                ProductId = product.Id,
                Quantity = 1,
                ShoppingCartId = shoppingCart.Id,

            };

            UpdateEntity(selectedItem);

            return selectedItem;

        }

        public override async Task<SelectedItem> InsertAsync(Guid selectedItemGuid)
        {
            SelectedItem selectedItem = await GetTestSelectedItem(selectedItemGuid);

            await _unitOfWork.SelectedItemRepository.InsertAsync(selectedItem, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return selectedItem;
        }

        public override async Task DeleteAsync(Guid selectedItemGuid)
        {
            SelectedItem selectedItem = await _unitOfWork.SelectedItemRepository.GetByGuidAsync(selectedItemGuid, _token);

            _unitOfWork.SelectedItemRepository.Delete(selectedItem, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _shoppingCartHelper.DeleteAsync(Constants.ShoppingCartGuid);
            await _shoppingCartHelper.CleanUpAsync();
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();
        }

    }
}
