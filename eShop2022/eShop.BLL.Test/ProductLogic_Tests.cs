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
        private readonly ProductLogicHelper _ProductLogicHelper;

        public ProductLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _ProductLogicHelper = new ProductLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            ProductFullView productView;

            // Act
            productView = _ProductLogicHelper.Insert(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ProductMinimalView> products;

            // Act
            products = _appServices.ProductLogic.GetAll();

            // Assert
            Assert.IsTrue(products.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ProductFullView productView;

            // Act
            productView = _appServices.ProductLogic.GetByGuid(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newProductName = "Test New Product Name";
            ProductFullView productView;


            // Act
            productView = _appServices.ProductLogic.GetByGuid(Constants.ProductGuid);

            productView.Name = newProductName;
            _appServices.ProductLogic.Update(productView);

            productView = _appServices.ProductLogic.GetByGuid(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView) && productView.Name == newProductName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ProductFullView productView;

            // Act
            _ProductLogicHelper.Delete(Constants.ProductGuid);
            _ProductLogicHelper.CleanUp();

            productView = _appServices.ProductLogic.GetByGuid(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(productView.IsNull());
        }
    }
}