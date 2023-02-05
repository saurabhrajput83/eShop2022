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
        private readonly eShopDbContext _eShopDbContext;
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly BrandHelper _brandHelper;

        public BrandRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext(DBContextHelper.Options);
            _unitOfWork = new eShopUnitOfWork(_eShopDbContext);
            _brandHelper = new BrandHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Brand brand;

            // Act
            brand = _brandHelper.Insert(Constants.BrandGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Brand> brands;

            // Act
            brands = _unitOfWork.BrandRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(brands.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Brand brand;

            // Act
            brand = _unitOfWork.BrandRepository.GetByGuid(Constants.BrandGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Brand brand;
            string newName = "Test New Brand Name";

            // Act
            brand = _unitOfWork.BrandRepository.GetByGuid(Constants.BrandGuid);
            if (brand != null)
            {
                brand.Name = newName;
                _unitOfWork.BrandRepository.Update(brand);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateBrand(brand) && brand?.Name == newName);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Brand brand;

            // Act
            _brandHelper.Delete(Constants.BrandGuid);
            _brandHelper.CleanUp();

            brand = _unitOfWork.BrandRepository.GetByGuid(Constants.BrandGuid);

            //Assert
            Assert.IsTrue(brand.IsNull());
        }


    }
}