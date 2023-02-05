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
        private readonly VariationTypeHelper _variationTypeHelper;

        public VariationTypeRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _variationTypeHelper = new VariationTypeHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            VariationType variationType;

            // Act
            variationType = _variationTypeHelper.Insert(Constants.VariationTypeGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<VariationType> variationTypes;

            // Act
            variationTypes = _unitOfWork.VariationTypeRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(variationTypes.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            VariationType variationType;

            // Act
            variationType = _unitOfWork.VariationTypeRepository.GetByGuid(Constants.VariationTypeGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            VariationType variationType;
            string newName = "New Test VariationType";

            // Act
            variationType = _unitOfWork.VariationTypeRepository.GetByGuid(Constants.VariationTypeGuid);
            if (variationType != null)
            {
                variationType.Name = newName;
                _unitOfWork.VariationTypeRepository.Update(variationType);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateVariationType(variationType) && variationType?.Name == newName);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            VariationType variationType;

            // Act
            _variationTypeHelper.Delete(Constants.VariationTypeGuid);
            _variationTypeHelper.CleanUp();

            variationType = _unitOfWork.VariationTypeRepository.GetByGuid(Constants.VariationTypeGuid);

            //Assert
            Assert.IsTrue(variationType.IsNull());
        }


    }
}