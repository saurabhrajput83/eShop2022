using eShop.DAL.Entities;
using eShop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public class ReviewHelper : BaseHelper<Review>
    {
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly ProductHelper _productHelper;

        public ReviewHelper(IeShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productHelper = new ProductHelper(_unitOfWork);
        }

        public Review GetTestReview(Guid reviewGuid)
        {
            Product product = _productHelper.Insert(Constants.ProductGuid);

            Review review = new Review()
            {
                Guid = reviewGuid,
                ProductId = product.Id,
                Headline = "Test Review Headline",
                Comments = "Test Review Comments",
                IsApproved = false,
                IsHidden = false,
                Rating = 3
            };

            UpdateEntity(review);

            return review;

        }

        public override Review Insert(Guid reviewGuid)
        {
            Review review = GetTestReview(reviewGuid);

            _unitOfWork.ReviewRepository.Insert(review);
            _unitOfWork.SaveChanges();

            return review;
        }

        public override void Delete(Guid reviewGuid)
        {
            Review review = _unitOfWork.ReviewRepository.GetByGuid(Constants.ReviewGuid);

            _unitOfWork.ReviewRepository.Delete(review);
            _unitOfWork.SaveChanges();
        }

        public override void CleanUp()
        {
            _productHelper.Delete(Constants.ProductGuid);
            _productHelper.CleanUp();
        }

    }
}
