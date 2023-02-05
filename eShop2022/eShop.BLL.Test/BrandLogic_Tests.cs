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
        private readonly BrandLogicHelper _brandLogicHelper;

        public BrandLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _brandLogicHelper = new BrandLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            brandView = await _brandLogicHelper.InsertAsync(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<BrandMinimalView> brands;

            // Act
            brands = await _appServices.BrandLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            brandView = await _appServices.BrandLogic.GetByGuidAsync(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newBrandName = "Test New Brand Name";
            BrandFullView brandView;


            // Act
            brandView = await _appServices.BrandLogic.GetByGuidAsync(Constants.BrandGuid);

            brandView.Name = newBrandName;
            await _appServices.BrandLogic.UpdateAsync(brandView);

            brandView = await _appServices.BrandLogic.GetByGuidAsync(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brandView) && brandView.Name == newBrandName);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            BrandFullView brandView;

            // Act
            await _brandLogicHelper.DeleteAsync(Constants.BrandGuid);
            await _brandLogicHelper.CleanUpAsync();

            brandView = await _appServices.BrandLogic.GetByGuidAsync(Constants.BrandGuid);

            // Assert
            Assert.IsTrue(brandView.IsNull());
        }
    }
}