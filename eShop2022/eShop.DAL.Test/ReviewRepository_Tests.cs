using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.UnitOfWork;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace eShop.DAL.Test
{
    [TestClass]
    public class ReviewRepository_Tests : Base_Test
    {
        private readonly AppDbContext _eShopDbContext;
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ReviewHelper _reviewHelper;

        public ReviewRepository_Tests()
        {
            _eShopDbContext = new AppDbContext(DBContextHelper.Options);
            _unitOfWork = new AppUnitOfWork(_eShopDbContext);
            _token = new CancellationToken();
            _reviewHelper = new ReviewHelper(_unitOfWork, _token);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public async Task Test1_Insert()
        {
            //Arrange
            Review review;

            // Act
            review = await _reviewHelper.InsertAsync(Constants.ReviewGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review));

        }

        [TestMethod]
        public async Task Test2_GetAll()
        {
            //Arrange
            List<Review> inventories;

            // Act
            inventories = await _unitOfWork.ReviewRepository.GetAllAsync(_token);

            //Assert
            Assert.IsTrue(inventories.IsNotEmpty());
        }

        [TestMethod]
        public async Task Test3_GetByGuid()
        {
            //Arrange
            Review review;

            // Act
            review = await _unitOfWork.ReviewRepository.GetByGuidAsync(Constants.ReviewGuid, _token);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review));
        }

        [TestMethod]
        public async Task Test4_Update()
        {
            //Arrange
            Review review;
            string newHeadline = "Test Review New Headline";
            string newComments = "Test Review New Comments";

            // Act
            review = await _unitOfWork.ReviewRepository.GetByGuidAsync(Constants.ReviewGuid, _token);
            if (review != null)
            {
                review.Headline = newHeadline;
                review.Comments = newComments;
                _unitOfWork.ReviewRepository.Update(review, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review)
                && review.Headline == newHeadline && review.Comments == newComments);
        }


        [TestMethod]
        public async Task Test5_Delete()
        {
            //Arrange
            Review review;

            // Act
            await _reviewHelper.DeleteAsync(Constants.ReviewGuid);
            await _reviewHelper.CleanUpAsync();

            review = await _unitOfWork.ReviewRepository.GetByGuidAsync(Constants.ReviewGuid, _token);

            //Assert
            Assert.IsTrue(review.IsNull());
        }


    }
}