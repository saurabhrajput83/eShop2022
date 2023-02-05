using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
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
    public class VariationLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly VariationLogicHelper _variationLogicHelper;

        public VariationLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _variationLogicHelper = new VariationLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            variationView = await _variationLogicHelper.InsertAsync(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<VariationMinimalView> variations;

            // Act
            variations = await _appServices.VariationLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(variations.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            variationView = await _appServices.VariationLogic.GetByGuidAsync(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newVariationName = "Test New Variation Name";
            VariationFullView variationView;


            // Act
            variationView = await _appServices.VariationLogic.GetByGuidAsync(Constants.VariationGuid);

            variationView.Name = newVariationName;
            await _appServices.VariationLogic.UpdateAsync(variationView);

            variationView = await _appServices.VariationLogic.GetByGuidAsync(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView) && variationView.Name == newVariationName);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            await _variationLogicHelper.DeleteAsync(Constants.VariationGuid);
            await _variationLogicHelper.CleanUpAsync();

            variationView = await _appServices.VariationLogic.GetByGuidAsync(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(variationView.IsNull());
        }
    }
}