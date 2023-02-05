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
        private readonly ReviewLogicHelper _reviewLogicHelper;

        public ReviewLogic_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _appServices = new AppServices(_unitOfWork);
            _reviewLogicHelper = new ReviewLogicHelper(_appServices);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1_Insert()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            reviewView = await _reviewLogicHelper.InsertAsync(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView));
        }

        [Test]
        public async Task Test2_GetAll()
        {
            // Arrange
            List<ReviewView> reviews;

            // Act
            reviews = await _appServices.ReviewLogic.GetAllAsync();

            // Assert
            Assert.IsTrue(reviews.IsNotEmpty());
        }

        [Test]
        public async Task Test3_GetByGuid()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            reviewView = await _appServices.ReviewLogic.GetByGuidAsync(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView));
        }

        [Test]
        public async Task Test4_Update()
        {
            // Arrange
            string newHeadline = "Test New Review Headline";
            ReviewView reviewView;


            // Act
            reviewView = await _appServices.ReviewLogic.GetByGuidAsync(Constants.ReviewGuid);

            reviewView.Headline = newHeadline;
            _appServices.ReviewLogic.UpdateAsync(reviewView);

            reviewView = await _appServices.ReviewLogic.GetByGuidAsync(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView) && reviewView.Headline == newHeadline);
        }

        [Test]
        public async Task Test5_Delete()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            await _reviewLogicHelper.DeleteAsync(Constants.ReviewGuid);
            await _reviewLogicHelper.CleanUpAsync();

            reviewView = await _appServices.ReviewLogic.GetByGuidAsync(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(reviewView.IsNull());
        }
    }
}