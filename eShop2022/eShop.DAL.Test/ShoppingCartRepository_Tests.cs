using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class ShoppingCartRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCartHelper _shoppingCartHelper;

        public ShoppingCartRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _shoppingCartHelper = new ShoppingCartHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            shoppingCart = _shoppingCartHelper.Insert(Constants.ShoppingCartGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCart));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<ShoppingCart> shoppingCarts;

            // Act
            shoppingCarts = _unitOfWork.ShoppingCartRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(shoppingCarts.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            shoppingCart = _unitOfWork.ShoppingCartRepository.GetByGuid(Constants.ShoppingCartGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCart));
        }

        //[TestMethod]
        //public void Test4_Update()
        //{
        //    //Arrange
        //    ShoppingCart shoppingCart;
        //    string newName = "New Test ShoppingCart";

        //    // Act
        //    shoppingCart = _unitOfWork.ShoppingCartRepository.GetByGuid(_shoppingCartGuid);
        //    if (shoppingCart != null)
        //    {
        //        shoppingCart. = newName;
        //        _unitOfWork.ShoppingCartRepository.Update(shoppingCart);
        //        _unitOfWork.Save();
        //    }

        //    //Assert
        //    Assert.IsTrue(shoppingCart != null && shoppingCart.Id > 0 && shoppingCart.Name == newName);
        //}


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            _shoppingCartHelper.Delete(Constants.ShoppingCartGuid);
            _shoppingCartHelper.CleanUp();

            shoppingCart = _unitOfWork.ShoppingCartRepository.GetByGuid(Constants.ShoppingCartGuid);

            //Assert
            Assert.IsTrue(shoppingCart.IsNull());
        }


    }
}