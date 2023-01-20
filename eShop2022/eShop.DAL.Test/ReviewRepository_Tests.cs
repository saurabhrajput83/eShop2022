using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using eShop.DAL.Test.Helpers;
using eShop.Infrastructure.Extensions;
using System.Runtime.CompilerServices;

namespace eShop.DAL.Test
{
    [TestClass]
    public class ReviewRepository_Tests : Base_Test
    {
        private readonly eShopDbContext _eShopDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReviewHelper _reviewHelper;

        public ReviewRepository_Tests()
        {
            _eShopDbContext = new eShopDbContext();
            _unitOfWork = new UnitOfWork(_eShopDbContext);
            _reviewHelper = new ReviewHelper(_unitOfWork);
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Test1_Insert()
        {
            //Arrange
            Review review;

            // Act
            review = _reviewHelper.Insert(Constants.ReviewGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review));

        }

        [TestMethod]
        public void Test2_GetAll()
        {
            //Arrange
            List<Review> inventories;

            // Act
            inventories = _unitOfWork.ReviewRepository.GetAll().ToList();

            //Assert
            Assert.IsTrue(inventories.IsNotEmpty());
        }

        [TestMethod]
        public void Test3_GetByGuid()
        {
            //Arrange
            Review review;

            // Act
            review = _unitOfWork.ReviewRepository.GetByGuid(Constants.ReviewGuid);

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review));
        }

        [TestMethod]
        public void Test4_Update()
        {
            //Arrange
            Review review;
            string newHeadline = "Test Review New Headline";
            string newComments = "Test Review New Comments";

            // Act
            review = _unitOfWork.ReviewRepository.GetByGuid(Constants.ReviewGuid);
            if (review != null)
            {
                review.Headline = newHeadline;
                review.Comments = newComments;
                _unitOfWork.ReviewRepository.Update(review);
                _unitOfWork.SaveChanges();
            }

            //Assert
            Assert.IsTrue(ValidationHelper.ValidateReview(review)
                && review.Headline == newHeadline && review.Comments == newComments);
        }


        [TestMethod]
        public void Test5_Delete()
        {
            //Arrange
            Review review;

            // Act
            _reviewHelper.Delete(Constants.ReviewGuid);
            _reviewHelper.CleanUp();

            review = _unitOfWork.ReviewRepository.GetByGuid(Constants.ReviewGuid);

            //Assert
            Assert.IsTrue(review.IsNull());
        }


    }
}