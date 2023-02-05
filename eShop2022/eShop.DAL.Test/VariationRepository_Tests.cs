using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Test
{
    [TestClass]
    public class VariationRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly VariationHelper _variationHelper;

        public VariationRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext(DBContextHelper.Options);
            _unitOfWork = new eShopUnitOfWork(_eShopDbContext);
            _variationHelper = new VariationHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Variation variation;

            // Act
            variation = _variationHelper.Insert(Constants.VariationGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Variation> variations;

            // Act
            variations = _unitOfWork.VariationRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(variations.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Variation variation;

            // Act
            variation = _unitOfWork.VariationRepository.GetByGuid(Constants.VariationGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Variation variation;
            string newName = "New Test Variation";

            // Act
            variation = _unitOfWork.VariationRepository.GetByGuid(Constants.VariationGuid);
            if (variation != null)
            {
                variation.Name = newName;
                _unitOfWork.VariationRepository.Update(variation);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation) && variation?.Name == newName);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Variation variation;

            // Act
            _variationHelper.Delete(Constants.VariationGuid);
            _variationHelper.CleanUp();

            variation = _unitOfWork.VariationRepository.GetByGuid(Constants.VariationGuid);

            //Assert
            Assert.IsTrue(variation.IsNull());
        }


    }
}