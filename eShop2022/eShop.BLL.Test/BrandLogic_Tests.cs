using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.BLL.Logics;
using eShop.BLL.Test.Helpers;
using eShop.DAL.Implementations;
using eShop.DAL.Main;
using eShop.DAL.UnitOfWork;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using eShop.BLL.Services;

namespace eShop.BLL.Test
{
    public class BrandLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly BrandLogicHelper _BrandLogicHelper;

        public BrandLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _BrandLogicHelper = new BrandLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            brandView = _BrandLogicHelper.Insert(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<BrandMinimalView> brands;

            // Act
            brands = _appServices.BrandLogic.GetAll();

            // Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            brandView = _appServices.BrandLogic.GetByGuid(Constants.BrandGuid);

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
            brandView = _appServices.BrandLogic.GetByGuid(Constants.BrandGuid);

            brandView.Name = newBrandName;
            _appServices.BrandLogic.Update(brandView);

            brandView = _appServices.BrandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView) && brandView.Name == newBrandName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            _BrandLogicHelper.Delete(Constants.BrandGuid);
            _BrandLogicHelper.CleanUp();

            brandView = _appServices.BrandLogic.GetByGuid(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(brandView.IsNull());
        }
    }
}