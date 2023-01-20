using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class SelectedItemHelper : BaseHelper<SelectedItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductHelper _productHelper;
        private readonly ShoppingCartHelper _shoppingCartHelper;

        public SelectedItemHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productHelper = new ProductHelper(unitOfWork);
            _shoppingCartHelper = new ShoppingCartHelper(unitOfWork);
        }

        public SelectedItem GetTestSelectedItem(Guid selectedItemGuid)
        {
            Product product = _productHelper.Insert(Constants.ProductGuid);
            ShoppingCart shoppingCart = _shoppingCartHelper.Insert(Constants.ShoppingCartGuid);

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

        public override SelectedItem Insert(Guid selectedItemGuid)
        {
            SelectedItem selectedItem = GetTestSelectedItem(selectedItemGuid);

            _unitOfWork.SelectedItemRepository.Insert(selectedItem);
            _unitOfWork.SaveChanges();

            return selectedItem;
        }

        public override void Delete(Guid selectedItemGuid)
        {
            SelectedItem selectedItem = _unitOfWork.SelectedItemRepository.GetByGuid(selectedItemGuid);

            _unitOfWork.SelectedItemRepository.Delete(selectedItem);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _shoppingCartHelper.Delete(Constants.ShoppingCartGuid);
            _shoppingCartHelper.CleanUp();
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();
        }

    }
}
