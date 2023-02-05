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
    public class VariationTypeLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly VariationTypeLogicHelper _variationTypeLogicHelper;

        public VariationTypeLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _variationTypeLogicHelper = new VariationTypeLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            variationTypeView = await _variationTypeLogicHelper.InsertAsync(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<VariationTypeMinimalView> variationTypes;

            // Act
            variationTypes = await _appServices.VariationTypeLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(variationTypes.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuidAsync()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            variationTypeView = await _appServices.VariationTypeLogic.GetByGuidAsync(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newVariationTypeName = "Test New VariationType Name";
            VariationTypeFullView variationTypeView;


            // Act
            variationTypeView = await _appServices.VariationTypeLogic.GetByGuidAsync(Constants.VariationTypeGuid);

            variationTypeView.Name = newVariationTypeName;
            await _appServices.VariationTypeLogic.UpdateAsync(variationTypeView);

            variationTypeView = await _appServices.VariationTypeLogic.GetByGuidAsync(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView) && variationTypeView.Name == newVariationTypeName);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            await _variationTypeLogicHelper.DeleteAsync(Constants.VariationTypeGuid);
            await _variationTypeLogicHelper.CleanUpAsync();

            variationTypeView = await _appServices.VariationTypeLogic.GetByGuidAsync(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(variationTypeView.IsNull());
        }
    }
}