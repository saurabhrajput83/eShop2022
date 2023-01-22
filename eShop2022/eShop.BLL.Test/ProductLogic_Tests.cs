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
    public class ProductLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly ProductLogicHelper _productLogicHelper;

        public ProductLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _productLogicHelper = new ProductLogicHelper(_logicHelper);
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
            productView = _productLogicHelper.Insert(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ProductMinimalView> products;

            // Act
            products = _logicHelper.ProductLogic.GetAll();

            // Assert
            Assert.IsTrue(products.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ProductFullView productView;

            // Act
            productView = _logicHelper.ProductLogic.GetByGuid(Constants.ProductGuid);

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
            productView = _logicHelper.ProductLogic.GetByGuid(Constants.ProductGuid);

            productView.Name = newProductName;
            _logicHelper.ProductLogic.Update(productView);

            productView = _logicHelper.ProductLogic.GetByGuid(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(productView) && productView.Name == newProductName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ProductFullView productView;

            // Act
            _productLogicHelper.Delete(Constants.ProductGuid);
            _productLogicHelper.CleanUp();

            productView = _logicHelper.ProductLogic.GetByGuid(Constants.ProductGuid);

            // Assert
            Assert.IsTrue(productView.IsNull());
        }
    }
}