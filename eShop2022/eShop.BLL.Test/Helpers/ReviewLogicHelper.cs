using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL.Services;

namespace eShop.BLL.Test.Helpers
{
    public class ReviewLogicHelper : BaseHelper<ReviewView>
    {
        private readonly IAppServices _appServices;
        private readonly ProductLogicHelper _productLogicHelper;

        public ReviewLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _productLogicHelper = new ProductLogicHelper(_appServices);
        }

        public async Task<ReviewView> GetTestReviewView(Guid reviewGuid)
        {
            ProductFullView product = await _productLogicHelper.InsertAsync(Constants.ProductGuid);

            ReviewView reviewView = new ReviewView()
            {
                Guid = reviewGuid,
                ProductId = product.Id,
                Headline = "Test Review Headline",
                Comments = "Test Review Comments",
                IsApproved = false,
                IsHidden = false,
                Rating = 3
            };

            UpdateView(reviewView);

            return reviewView;

        }

        public override async Task<ReviewView> InsertAsync(Guid reviewGuid)
        {
            ReviewView reviewView = await GetTestReviewView(reviewGuid);
            return await _appServices.ReviewLogic.InsertAsync(reviewView);
        }

        public override async Task DeleteAsync(Guid reviewGuid)
        {
            await _appServices.ReviewLogic.DeleteAsync(reviewGuid);
        }

        public override async Task CleanUpAsync()
        {
            await _productLogicHelper.DeleteAsync(Constants.ProductGuid);
            await _productLogicHelper.CleanUpAsync();
        }

    }
}
