using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class BrandRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly BrandHelper _brandHelper;


        public BrandRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _brandHelper = new BrandHelper(_unitOfWork, _token);

        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Brand brand;

            // Act
            brand = await _brandHelper.InsertAsync(Constants.BrandGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Brand> brands;

            // Act
            brands = await _unitOfWork.BrandRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Brand brand;

            // Act
            brand = await _unitOfWork.BrandRepository.GetByGuidAsync(Constants.BrandGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Brand brand;
            string newName = "Test New Brand Name";

            // Act
            brand = await _unitOfWork.BrandRepository.GetByGuidAsync(Constants.BrandGuid, _token);
            if (brand != null)
            {
                brand.Name = newName;
                _unitOfWork.BrandRepository.Update(brand, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand) && brand?.Name == newName);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Brand brand;

            // Act
            await _brandHelper.DeleteAsync(Constants.BrandGuid);
            await _brandHelper.CleanUpAsync();

            brand = await _unitOfWork.BrandRepository.GetByGuidAsync(Constants.BrandGuid, _token);

            //Assert
            Assert.IsTrue(brand.IsNull());
        }


    }
}