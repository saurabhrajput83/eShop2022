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
        private readonly ProductLogicHelper _ProductLogicHelper;

        public ReviewLogicHelper(IAppServices AppServices)
        {
            _appServices = AppServices;
            _ProductLogicHelper= new ProductLogicHelper(_appServices);
        }

        public ReviewView GetTestReviewView(Guid reviewGuid)
        {
            ProductFullView product = _ProductLogicHelper.Insert(Constants.ProductGuid);

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

        public override ReviewView Insert(Guid reviewGuid)
        {
            ReviewView reviewView = GetTestReviewView(reviewGuid);
            return _appServices.ReviewLogic.Insert(reviewView);
        }

        public override void Delete(Guid reviewGuid)
        {
            _appServices.ReviewLogic.Delete(reviewGuid);
        }

        public override void CleanUp()
        {
            _ProductLogicHelper.Delete(Constants.ProductGuid);
            _ProductLogicHelper.CleanUp();
        }

    }
}
