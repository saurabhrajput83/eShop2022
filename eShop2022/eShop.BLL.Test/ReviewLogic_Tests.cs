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
    public class ReviewLogic_Tests
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogicHelper _logicHelper;
        private readonly ReviewLogicHelper _reviewLogicHelper;
        
        public ReviewLogic_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _logicHelper = new LogicHelper(_unitOfWork);
            _reviewLogicHelper = new ReviewLogicHelper(_logicHelper);
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
            reviewView = _reviewLogicHelper.Insert(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView));
        }

        [Test]
        public void Test2_GetAll()
        {
            // Arrange
            List<ReviewView> reviews;

            // Act
            reviews = _logicHelper.ReviewLogic.GetAll();

            // Assert
            Assert.IsTrue(reviews.IsNotEmpty());
        }

        [Test]
        public void Test3_GetByGuid()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            reviewView = _logicHelper.ReviewLogic.GetByGuid(Constants.ReviewGuid);

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
            reviewView = _logicHelper.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            reviewView.Headline = newHeadline;
            _logicHelper.ReviewLogic.Update(reviewView);

            reviewView = _logicHelper.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(reviewView) && reviewView.Headline == newHeadline);
        }

        [Test]
        public void Test5_Delete()
        {
            // Arrange
            ReviewView reviewView;

            // Act
            _reviewLogicHelper.Delete(Constants.ReviewGuid);
            _reviewLogicHelper.CleanUp();

            reviewView = _logicHelper.ReviewLogic.GetByGuid(Constants.ReviewGuid);

            // Assert
            Assert.IsTrue(reviewView.IsNull());
        }
    }
}