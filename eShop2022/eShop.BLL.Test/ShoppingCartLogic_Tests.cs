using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace eShop.BLL.Test
{
    public class ShoppingCartLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly ShoppingCartLogicHelper _shoppingCartLogicHelper;
        
        public ShoppingCartLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _shoppingCartLogicHelper = new ShoppingCartLogicHelper(_logicHelper);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            shoppingCartView = _shoppingCartLogicHelper.Insert(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ShoppingCartView> shoppingCarts;

            // Act
            shoppingCarts = _logicHelper.ShoppingCartLogic.GetAll();

            // Assert
            Assert.IsTrue(shoppingCarts.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            shoppingCartView = _logicHelper.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView));
        }

        //[Test]
        //public void Test4_Update()
        //{
        //    // Arrange
        //    string newShoppingCartName = "Test New ShoppingCart Name";
        //    ShoppingCartView shoppingCartView;


        //    // Act
        //    shoppingCartView = _logicHelper.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

        //    shoppingCartView.Name = newShoppingCartName;
        //    _logicHelper.ShoppingCartLogic.Update(shoppingCartView);

        //    shoppingCartView = _logicHelper.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView) && shoppingCartView.Name == newShoppingCartName);
        //}

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            _shoppingCartLogicHelper.Delete(Constants.ShoppingCartGuid);
            _shoppingCartLogicHelper.CleanUp();

            shoppingCartView = _logicHelper.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(shoppingCartView.IsNull());
        }
    }
}