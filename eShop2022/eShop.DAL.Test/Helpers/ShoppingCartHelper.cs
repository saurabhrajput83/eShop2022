using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ShoppingCartHelper : BaseHelper<ShoppingCart>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;

        public ShoppingCartHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
        }

        public ShoppingCart GetTestShoppingCart(Guid shoppingCartGuid)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Guid = shoppingCartGuid
            };

            UpdateEntity(shoppingCart);

            return shoppingCart;

        }

        public override async Task<ShoppingCart> InsertAsync(Guid shoppingCartGuid)
        {
            ShoppingCart shoppingCart = GetTestShoppingCart(shoppingCartGuid);

            await _unitOfWork.ShoppingCartRepository.InsertAsync(shoppingCart, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return shoppingCart;
        }

        public override async Task DeleteAsync(Guid shoppingCartGuid)
        {
            ShoppingCart shoppingCart = await _unitOfWork.ShoppingCartRepository.GetByGuidAsync(shoppingCartGuid, _token);

            _unitOfWork.ShoppingCartRepository.Delete(shoppingCart, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
        }

    }
}
