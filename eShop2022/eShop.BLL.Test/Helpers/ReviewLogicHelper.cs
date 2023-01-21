using AutoMapper;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.BLL.Logging;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;
using eShop.DAL.Infrastructure;
using eShop.DAL.Main;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Test.Helpers
{
    public class ReviewLogicHelper : BaseHelper<ReviewView>
    {
        private readonly ILogicHelper _logicHelper;
        private readonly ProductLogicHelper _productLogicHelper;

        public ReviewLogicHelper(ILogicHelper logicHelper)
        {
            _logicHelper = logicHelper;
            _productLogicHelper= new ProductLogicHelper(_logicHelper);
        }

        public ReviewView GetTestReviewView(Guid reviewGuid)
        {
            ProductFullView product = _productLogicHelper.Insert(Constants.ProductGuid);

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
            return _logicHelper.ReviewLogic.Insert(reviewView);
        }

        public override void Delete(Guid reviewGuid)
        {
            _logicHelper.ReviewLogic.Delete(reviewGuid);
        }

        public override void CleanUp()
        {
        }

    }
}
