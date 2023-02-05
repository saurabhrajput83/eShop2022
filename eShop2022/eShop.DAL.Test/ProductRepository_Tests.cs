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
    public class ProductRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ProductHelper _productHelper;
        private readonly BrandHelper _brandHelper;

        public ProductRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _productHelper = new ProductHelper(_unitOfWork, _token);
            _brandHelper = new BrandHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Product product;

            // Act
            product = await _productHelper.InsertAsync(Constants.ProductGuid);

            //Assert
            Assert.IsTrue(product.Id > 0);

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Product> products;

            // Act
            products = await _unitOfWork.ProductRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(products.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Product product;

            // Act
            product = await _unitOfWork.ProductRepository.GetByGuidAsync(Constants.ProductGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(product));
            Assert.IsTrue(ValidationHelper.ValidateBrand(product.Brand));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Product product;
            string newName = "New Test Product";

            // Act
            product = await _unitOfWork.ProductRepository.GetByGuidAsync(Constants.ProductGuid, _token);
            if (product != null)
            {
                product.Name = newName;
                _unitOfWork.ProductRepository.Update(product, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(product?.Id > 0 && product?.Name == newName);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Product product;

            // Act
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();

            product = await _unitOfWork.ProductRepository.GetByGuidAsync(Constants.ProductGuid, _token);

            //Assert
            Assert.IsTrue(product == null || product.Id == 0);

        }


    }
}