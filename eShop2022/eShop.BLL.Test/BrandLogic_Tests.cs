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
    public class BrandLogic_Tests : Base_Test
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BrandLogic> _logger;
        private readonly IBrandLogic _brandLogic;
        private readonly BrandHelper _brandHelper;

        public BrandLogic_Tests()
        {
            _mapper = AutoMapperConfiguration.Configure();
            _logger = LoggerConfiguration.Configuration<BrandLogic>();
            _brandLogic = new BrandLogic(eShopUnitOfWork, _mapper, _logger);
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
            BrandFullView brandView = BrandHelper.GetTestBrandView(Constants.BrandGuid);

            // Act
            brandView = _brandHelper.Insert(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<BrandMinimalView> brands;

            // Act
            brands = _brandLogic.GetAll();

            // Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            BrandFullView brandView;

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
            BrandFullView brandView;


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
            BrandFullView brandView;

            // Act
            _brandHelper.Delete(Constants.BrandGuid);
            _brandHelper.CleanUp();

            brandView = _brandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(brandView.IsNull());
        }
    }
}