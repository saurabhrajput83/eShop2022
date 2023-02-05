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
        private readonly VariationLogicHelper _VariationLogicHelper;
        
        public VariationLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _VariationLogicHelper = new VariationLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            variationView = _VariationLogicHelper.Insert(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<VariationMinimalView> variations;

            // Act
            variations = _appServices.VariationLogic.GetAll();

            // Assert
            Assert.IsTrue(variations.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            variationView = _appServices.VariationLogic.GetByGuid(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newVariationName = "Test New Variation Name";
            VariationFullView variationView;


            // Act
            variationView = _appServices.VariationLogic.GetByGuid(Constants.VariationGuid);

            variationView.Name = newVariationName;
            _appServices.VariationLogic.Update(variationView);

            variationView = _appServices.VariationLogic.GetByGuid(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView) && variationView.Name == newVariationName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            _VariationLogicHelper.Delete(Constants.VariationGuid);
            _VariationLogicHelper.CleanUp();

            variationView = _appServices.VariationLogic.GetByGuid(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(variationView.IsNull());
        }
    }
}