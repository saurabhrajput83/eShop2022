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
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly VariationHelper _variationHelper;

        public VariationRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _variationHelper = new VariationHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Variation variation;

            // Act
            variation = await _variationHelper.InsertAsync(Constants.VariationGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Variation> variations;

            // Act
            variations = await _unitOfWork.VariationRepository.GetAllAsync(_token);
            //Assert
            Assert.IsTrue(variations.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Variation variation;

            // Act
            variation = await _unitOfWork.VariationRepository.GetByGuidAsync(Constants.VariationGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Variation variation;
            string newName = "New Test Variation";

            // Act
            variation = await _unitOfWork.VariationRepository.GetByGuidAsync(Constants.VariationGuid, _token);
            if (variation != null)
            {
                variation.Name = newName;
                _unitOfWork.VariationRepository.Update(variation, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariation(variation) && variation?.Name == newName);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Variation variation;

            // Act
            await _variationHelper.DeleteAsync(Constants.VariationGuid);
            await _variationHelper.CleanUpAsync();

            variation = await _unitOfWork.VariationRepository.GetByGuidAsync(Constants.VariationGuid, _token);

            //Assert
            Assert.IsTrue(variation.IsNull());
        }


    }
}