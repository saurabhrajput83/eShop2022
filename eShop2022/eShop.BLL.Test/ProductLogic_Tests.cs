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
    public class ProductLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly ProductLogicHelper _productLogicHelper;

        public ProductLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _productLogicHelper = new ProductLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            ProductFullView productView;

            // Act
            productView = await _productLogicHelper.InsertAsync(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<ProductMinimalView> products;

            // Act
            products = await _appServices.ProductLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(products.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            ProductFullView productView;

            // Act
            productView = await _appServices.ProductLogic.GetByGuidAsync(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newProductName = "Test New Product Name";
            ProductFullView productView;


            // Act
            productView = await _appServices.ProductLogic.GetByGuidAsync(Constants.ProductGuid);

            productView.Name = newProductName;
            await _appServices.ProductLogic.UpdateAsync(productView);

            productView = await _appServices.ProductLogic.GetByGuidAsync(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView) && productView.Name == newProductName);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            ProductFullView productView;

            // Act
            await _productLogicHelper.DeleteAsync(Constants.ProductGuid);
            await _productLogicHelper.CleanUpAsync();

            productView = await _appServices.ProductLogic.GetByGuidAsync(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(productView.IsNull());
        }
    }
}