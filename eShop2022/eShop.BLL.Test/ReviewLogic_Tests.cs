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
    public class ReviewLogic_Tests
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IAppServices _appServices;
        private readonly ReviewLogicHelper _ReviewLogicHelper;
        
        public ReviewLogic_Tests()
        {
             _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _ReviewLogicHelper = new ReviewLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Insert()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            reviewView = _ReviewLogicHelper.Insert(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ReviewView> reviews;

            // Act
            reviews = _appServices.ReviewLogic.GetAll();

            // Assert
            Assert.IsTrue(reviews.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            reviewView = _appServices.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView));
        }

        [Test]
        public void Test4_Update()
        {
            // Arrange
            string newHeadline = "Test New Review Headline";
            ReviewView reviewView;


            // Act
            reviewView = _appServices.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            reviewView.Headline = newHeadline;
            _appServices.ReviewLogic.Update(reviewView);

            reviewView = _appServices.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView) && reviewView.Headline == newHeadline);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            _ReviewLogicHelper.Delete(Constants.ReviewGuid);
            _ReviewLogicHelper.CleanUp();

            reviewView = _appServices.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(reviewView.IsNull());
        }
    }
}