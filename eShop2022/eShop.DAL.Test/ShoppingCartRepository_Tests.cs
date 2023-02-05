using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Test
{
    [TestClass]
    public class ShoppingCartRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ShoppingCartHelper _shoppingCartHelper;

        public ShoppingCartRepository_Tests()
        {

            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _shoppingCartHelper = new ShoppingCartHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            shoppingCart = await _shoppingCartHelper.InsertAsync(Constants.ShoppingCartGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCart));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<ShoppingCart> shoppingCarts;

            // Act
            shoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(shoppingCarts.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            shoppingCart = await _unitOfWork.ShoppingCartRepository.GetByGuidAsync(Constants.ShoppingCartGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateShoppingCart(shoppingCart));
        }

        //[TestMethod]
        //public async Task Test4_Update()
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
        public async Task Test5_Delete()
        {
            //Arrange
            ShoppingCart shoppingCart;

            // Act
            await _shoppingCartHelper.DeleteAsync(Constants.ShoppingCartGuid);
            await _shoppingCartHelper.CleanUpAsync();

            shoppingCart = await _unitOfWork.ShoppingCartRepository.GetByGuidAsync(Constants.ShoppingCartGuid, _token);

            //Assert
            Assert.IsTrue(shoppingCart.IsNull());
        }


    }
}