using AutoMapper;
using AutoMapper.Internal;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Interfaces;
using eShop.DAL.Entities;
using eShop.DAL.Implementations;

using eShop.DAL.Main;
using eShop.DAL.UnitOfWork;
using eShop.Infrastructure;
using eShop.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Logics
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly IeShopUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewLogic> _logger;


        public ReviewLogic(IeShopUnitOfWork unitOfWork, IMapper mapper, ILogger<ReviewLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public void Delete(Guid reviewGuid)
        {
            try
            {
                Review reviewEntity = _unitOfWork.ReviewRepository.GetByGuid(reviewGuid);
                if (reviewEntity.IsNotNull())
                {
                    _unitOfWork.ReviewRepository.Delete(reviewEntity);
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Delete");
                throw;
            }
        }

        public List<ReviewView> GetAll()
        {
            try
            {
                List<Review> result = _unitOfWork.ReviewRepository.GetAll().ToList();
                return _mapper.Map<List<ReviewView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.GetAll");
                throw;
            }
        }

        public ReviewView GetByGuid(Guid reviewGuid)
        {
            try
            {
                Review reviewEntity = _unitOfWork.ReviewRepository.GetByGuid(reviewGuid);
                return _mapper.Map<ReviewView>(reviewEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.reviewGuid");
                throw;
            }
        }

        public ReviewView Insert(ReviewView reviewView)
        {
            try
            {
                Review reviewEntity = _mapper.Map<Review>(reviewView);
                _unitOfWork.ReviewRepository.Insert(reviewEntity);
                _unitOfWork.SaveChanges();
                return _mapper.Map<ReviewView>(reviewEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Insert");
                throw;
            }
        }

        public void Update(ReviewView reviewView)
        {
            try
            {
                Review reviewEntity = _mapper.Map<ReviewView, Review>(reviewView);
                _unitOfWork.ReviewRepository.Update(reviewEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Update");
                throw;
            }
        }
    }
}
