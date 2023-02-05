using AutoMapper;
using AutoMapper.Internal;
using eShop.BLL.AutoMapper;
using eShop.BLL.Dtos;
using eShop.BLL.Logics.Interfaces;
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
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly CancellationToken _token;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewLogic> _logger;


        public ReviewLogic(IAppUnitOfWork unitOfWork, IMapper mapper, ILogger<ReviewLogic> logger)
        {
            _unitOfWork = unitOfWork;
            _token = new CancellationToken();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid reviewGuid)
        {
            try
            {
                Review reviewEntity = await _unitOfWork.ReviewRepository.GetByGuidAsync(reviewGuid, _token);
                if (reviewEntity.IsNotNull())
                {
                    _unitOfWork.ReviewRepository.Delete(reviewEntity, _token);
                    await _unitOfWork.SaveChangesAsync(_token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Delete");
                throw;
            }
        }

        public async Task<List<ReviewView>> GetAllAsync()
        {
            try
            {
                List<Review> result = await _unitOfWork.ReviewRepository.GetAllAsync(_token);
                return _mapper.Map<List<ReviewView>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.GetAll");
                throw;
            }
        }

        public async Task<ReviewView> GetByGuidAsync(Guid reviewGuid)
        {
            try
            {
                Review reviewEntity = await _unitOfWork.ReviewRepository.GetByGuidAsync(reviewGuid, _token);
                return _mapper.Map<ReviewView>(reviewEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.reviewGuid");
                throw;
            }
        }

        public async Task<ReviewView> InsertAsync(ReviewView reviewView)
        {
            try
            {
                Review reviewEntity = _mapper.Map<Review>(reviewView);
                await _unitOfWork.ReviewRepository.InsertAsync(reviewEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
                return _mapper.Map<ReviewView>(reviewEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Insert");
                throw;
            }
        }

        public async Task UpdateAsync(ReviewView reviewView)
        {
            try
            {
                Review reviewEntity = await _unitOfWork.ReviewRepository.GetByGuidAsync(reviewView.Guid, _token);
                reviewEntity = _mapper.Map<ReviewView, Review>(reviewView, reviewEntity);
                _unitOfWork.ReviewRepository.Update(reviewEntity, _token);
                await _unitOfWork.SaveChangesAsync(_token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ReviewLogic.Update");
                throw;
            }
        }
    }
}
