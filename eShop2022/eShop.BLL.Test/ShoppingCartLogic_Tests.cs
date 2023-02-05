using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using eShop.BLL.Services;

namespace eShop.BLL.Test
{
    public class ShoppingCartLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly ShoppingCartLogicHelper _ShoppingCartLogicHelper;
        
        public ShoppingCartLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _ShoppingCartLogicHelper = new ShoppingCartLogicHelper(_appServices);
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
            shoppingCartView = _ShoppingCartLogicHelper.Insert(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ShoppingCartView> shoppingCarts;

            // Act
            shoppingCarts = _appServices.ShoppingCartLogic.GetAll();

            // Assert
            Assert.IsTrue(shoppingCarts.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            shoppingCartView = _appServices.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

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
        //    shoppingCartView = _appServices.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

        //    shoppingCartView.Name = newShoppingCartName;
        //    _appServices.ShoppingCartLogic.Update(shoppingCartView);

        //    shoppingCartView = _appServices.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView) && shoppingCartView.Name == newShoppingCartName);
        //}

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            _ShoppingCartLogicHelper.Delete(Constants.ShoppingCartGuid);
            _ShoppingCartLogicHelper.CleanUp();

            shoppingCartView = _appServices.ShoppingCartLogic.GetByGuid(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(shoppingCartView.IsNull());
        }
    }
}