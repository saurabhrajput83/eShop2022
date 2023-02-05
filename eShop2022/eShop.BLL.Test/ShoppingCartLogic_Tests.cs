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
        public async Task Test1_Insert()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            shoppingCartView = await _ShoppingCartLogicHelper.InsertAsync(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<ShoppingCartView> shoppingCarts;

            // Act
            shoppingCarts = await _appServices.ShoppingCartLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(shoppingCarts.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            shoppingCartView = await _appServices.ShoppingCartLogic.GetByGuidAsync(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView));
        }

        //[Test]
        //public async Task Test4_Update()
        //{
        //    // Arrange
        //    string newShoppingCartName = "Test New ShoppingCart Name";
        //    ShoppingCartView shoppingCartView;


        //    // Act
        //    shoppingCartView = _appServices.ShoppingCartLogic.GetByGuidAsync(Constants.ShoppingCartGuid);

        //    shoppingCartView.Name = newShoppingCartName;
        //    _appServices.ShoppingCartLogic.Update(shoppingCartView);

        //    shoppingCartView = _appServices.ShoppingCartLogic.GetByGuidAsync(Constants.ShoppingCartGuid);

        //    // Assert
        //    Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCartView) && shoppingCartView.Name == newShoppingCartName);
        //}

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            ShoppingCartView shoppingCartView;

            // Act
            await _ShoppingCartLogicHelper.DeleteAsync(Constants.ShoppingCartGuid);
            await _ShoppingCartLogicHelper.CleanUpAsync();

            shoppingCartView = await _appServices.ShoppingCartLogic.GetByGuidAsync(Constants.ShoppingCartGuid);

            // Assert
            Assert.IsTrue(shoppingCartView.IsNull());
        }
    }
}