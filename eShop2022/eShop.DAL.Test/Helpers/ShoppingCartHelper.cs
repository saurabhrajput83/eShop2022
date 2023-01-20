using eShop.DAL.Entities;
using eShop.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ShoppingCartHelper : BaseHelper<ShoppingCart>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public override ShoppingCart Insert(Guid shoppingCartGuid)
        {
            ShoppingCart shoppingCart = GetTestShoppingCart(shoppingCartGuid);

            _unitOfWork.ShoppingCartRepository.Insert(shoppingCart);
            _unitOfWork.SaveChanges();

            return shoppingCart;
        }

        public override void Delete(Guid shoppingCartGuid)
        {
            ShoppingCart shoppingCart = _unitOfWork.ShoppingCartRepository.GetByGuid(shoppingCartGuid);

            _unitOfWork.ShoppingCartRepository.Delete(shoppingCart);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
        }

    }
}
