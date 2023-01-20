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
    public class ProductRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductHelper _productHelper;
        private readonly BrandHelper _brandHelper;

        public ProductRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _productHelper = new ProductHelper(_unitOfWork);
            _brandHelper = new BrandHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Product product;

            // Act
            product = _productHelper.Insert(Constants.ProductGuid);

            //Assert
            Assert.IsTrue(product.Id > 0);

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Product> products;

            // Act
            products = _unitOfWork.ProductRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(products.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Product product;

            // Act
            product = _unitOfWork.ProductRepository.GetByGuid(Constants.ProductGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateProduct(product));
            Assert.IsTrue(ValidationHelper.ValidateBrand(product.Brand));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Product product;
            string newName = "New Test Product";

            // Act
            product = _unitOfWork.ProductRepository.GetByGuid(Constants.ProductGuid);
            if (product != null)
            {
                product.Name = newName;
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(product?.Id > 0 && product?.Name == newName);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Product product;

            // Act
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();

            product = _unitOfWork.ProductRepository.GetByGuid(Constants.ProductGuid);

            //Assert
            Assert.IsTrue(product == null || product.Id == 0);

        }


    }
}