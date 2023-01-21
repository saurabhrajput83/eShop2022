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
    public class BrandLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly BrandLogicHelper _brandLogicHelper;
        
        public BrandLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _brandLogicHelper = new BrandLogicHelper(_logicHelper);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            BrandFullView brandView = _brandLogicHelper.GetTestBrandView(Constants.BrandGuid);

            // Act
            brandView = _brandLogicHelper.Insert(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<BrandMinimalView> brands;

            // Act
            brands = _logicHelper.BrandLogic.GetAll();

            // Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            brandView = _logicHelper.BrandLogic.GetByGuid(Constants.BrandGuid);

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
            brandView = _logicHelper.BrandLogic.GetByGuid(Constants.BrandGuid);

            brandView.Name = newBrandName;
            _logicHelper.BrandLogic.Update(brandView);

            brandView = _logicHelper.BrandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView) && brandView.Name == newBrandName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            _brandLogicHelper.Delete(Constants.BrandGuid);
            _brandLogicHelper.CleanUp();

            brandView = _logicHelper.BrandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(brandView.IsNull());
        }
    }
}