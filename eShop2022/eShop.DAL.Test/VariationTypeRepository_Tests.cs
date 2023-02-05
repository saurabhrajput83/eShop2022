using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class VariationTypeRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly VariationTypeHelper _variationTypeHelper;

        public VariationTypeRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _variationTypeHelper = new VariationTypeHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            VariationType variationType;

            // Act
            variationType = await _variationTypeHelper.InsertAsync(Constants.VariationTypeGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<VariationType> variationTypes;

            // Act
            variationTypes = await _unitOfWork.VariationTypeRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(variationTypes.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            VariationType variationType;

            // Act
            variationType = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(Constants.VariationTypeGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            VariationType variationType;
            string newName = "New Test VariationType";

            // Act
            variationType = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(Constants.VariationTypeGuid, _token);
            if (variationType != null)
            {
                variationType.Name = newName;
                _unitOfWork.VariationTypeRepository.Update(variationType, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType) && variationType?.Name == newName);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            VariationType variationType;

            // Act
            await _variationTypeHelper.DeleteAsync(Constants.VariationTypeGuid);
            await _variationTypeHelper.CleanUpAsync();

            variationType = await _unitOfWork.VariationTypeRepository.GetByGuidAsync(Constants.VariationTypeGuid, _token);

            //Assert
            Assert.IsTrue(variationType.IsNull());
        }


    }
}