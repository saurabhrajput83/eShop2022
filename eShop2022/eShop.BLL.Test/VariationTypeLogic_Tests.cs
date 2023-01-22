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
    public class VariationTypeLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly VariationTypeLogicHelper _variationTypeLogicHelper;
        
        public VariationTypeLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _variationTypeLogicHelper = new VariationTypeLogicHelper(_logicHelper);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            variationTypeView = _variationTypeLogicHelper.Insert(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<VariationTypeMinimalView> variationTypes;

            // Act
            variationTypes = _logicHelper.VariationTypeLogic.GetAll();

            // Assert
            Assert.IsTrue(variationTypes.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            variationTypeView = _logicHelper.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newVariationTypeName = "Test New VariationType Name";
            VariationTypeFullView variationTypeView;


            // Act
            variationTypeView = _logicHelper.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            variationTypeView.Name = newVariationTypeName;
            _logicHelper.VariationTypeLogic.Update(variationTypeView);

            variationTypeView = _logicHelper.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView) && variationTypeView.Name == newVariationTypeName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            _variationTypeLogicHelper.Delete(Constants.VariationTypeGuid);
            _variationTypeLogicHelper.CleanUp();

            variationTypeView = _logicHelper.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(variationTypeView.IsNull());
        }
    }
}