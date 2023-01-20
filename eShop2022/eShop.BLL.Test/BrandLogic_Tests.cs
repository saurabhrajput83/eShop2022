using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.Infrastructure.Extensions;

namespace eShop.BLL.Test
{
    public class BrandLogic_Tests
    {
        private readonly IBrandLogic _brandLogic;
        private readonly BrandHelper _brandHelper;

        public BrandLogic_Tests()
        {
            _brandLogic = new BrandLogic();
            _brandHelper = new BrandHelper(_brandLogic);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            BrandView brandView = BrandHelper.GetTestBrandView(Constants.BrandGuid);

            // Act
            brandView = _brandHelper.Insert(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<BrandView> brands;

            // Act
            brands = _brandLogic.GetAll();

            // Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            BrandView brandView;

            // Act
            brandView = _brandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newBrandName = "Test New Brand Name";
            BrandView brandView;
            

            // Act
            brandView = _brandLogic.GetByGuid(Constants.BrandGuid);

            brandView.Name = newBrandName;
            _brandLogic.Update(brandView);
            
            brandView = _brandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView) && brandView.Name == newBrandName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            BrandView brandView;

            // Act
            _brandHelper.Delete(Constants.BrandGuid);
            _brandHelper.CleanUp();

            brandView = _brandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(brandView.IsNull());
        }
    }
}