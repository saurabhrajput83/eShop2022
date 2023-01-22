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
    public class VariationLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly VariationLogicHelper _variationLogicHelper;
        
        public VariationLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _variationLogicHelper = new VariationLogicHelper(_logicHelper);
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
            variationView = _variationLogicHelper.Insert(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<VariationMinimalView> variations;

            // Act
            variations = _logicHelper.VariationLogic.GetAll();

            // Assert
            Assert.IsTrue(variations.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            variationView = _logicHelper.VariationLogic.GetByGuid(Constants.VariationGuid);

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
            variationView = _logicHelper.VariationLogic.GetByGuid(Constants.VariationGuid);

            variationView.Name = newVariationName;
            _logicHelper.VariationLogic.Update(variationView);

            variationView = _logicHelper.VariationLogic.GetByGuid(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variationView) && variationView.Name == newVariationName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            VariationFullView variationView;

            // Act
            _variationLogicHelper.Delete(Constants.VariationGuid);
            _variationLogicHelper.CleanUp();

            variationView = _logicHelper.VariationLogic.GetByGuid(Constants.VariationGuid);

            // Assert
            Assert.IsTrue(variationView.IsNull());
        }
    }
}