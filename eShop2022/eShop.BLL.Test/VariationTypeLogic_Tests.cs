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
        private readonly VariationTypeLogicHelper _VariationTypeLogicHelper;
        
        public VariationTypeLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _VariationTypeLogicHelper = new VariationTypeLogicHelper(_appServices);
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
            variationTypeView = _VariationTypeLogicHelper.Insert(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<VariationTypeMinimalView> variationTypes;

            // Act
            variationTypes = _appServices.VariationTypeLogic.GetAll();

            // Assert
            Assert.IsTrue(variationTypes.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            variationTypeView = _appServices.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

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
            variationTypeView = _appServices.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            variationTypeView.Name = newVariationTypeName;
            _appServices.VariationTypeLogic.Update(variationTypeView);

            variationTypeView = _appServices.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationTypeView) && variationTypeView.Name == newVariationTypeName);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            VariationTypeFullView variationTypeView;

            // Act
            _VariationTypeLogicHelper.Delete(Constants.VariationTypeGuid);
            _VariationTypeLogicHelper.CleanUp();

            variationTypeView = _appServices.VariationTypeLogic.GetByGuid(Constants.VariationTypeGuid);

            // Assert
            Assert.IsTrue(variationTypeView.IsNull());
        }
    }
}