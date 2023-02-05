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
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly ProductHelper _productHelper;

        public ReviewHelper(IAppUnitOfWork unitOfWork, CancellationToken token)
        {
            _unitOfWork = unitOfWork;
            _token = token;
            _productHelper = new ProductHelper(_unitOfWork, _token);

        }

        public async Task<Review> GetTestReview(Guid reviewGuid)
        {
            Product product = await _productHelper.InsertAsync(Constants.ProductGuid);

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

        public override async Task<Review> InsertAsync(Guid reviewGuid)
        {
            Review review = await GetTestReview(reviewGuid);

            await _unitOfWork.ReviewRepository.InsertAsync(review, _token);
            await _unitOfWork.SaveChangesAsync(_token);

            return review;
        }

        public override async Task DeleteAsync(Guid reviewGuid)
        {
            Review review = await _unitOfWork.ReviewRepository.GetByGuidAsync(Constants.ReviewGuid, _token);

            _unitOfWork.ReviewRepository.Delete(review, _token);
            await _unitOfWork.SaveChangesAsync(_token);
        }

        public override async Task CleanUpAsync()
        {
            await _productHelper.DeleteAsync(Constants.ProductGuid);
            await _productHelper.CleanUpAsync();
        }

    }
}
